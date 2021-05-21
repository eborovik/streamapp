using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Streamer.Database;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Services
{
    public class SavedVideoService : ISavedVideoService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly Config _config;

        public SavedVideoService(DatabaseContext dbContext, IMapper mapper, 
            IFileService fileService, Config config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileService = fileService;
            _config = config;
        }

        public async Task StartRecording(string streamId)
        {
            var liveVideo = _dbContext.LiveVideos.FirstOrDefault(v => v.StreamId == streamId);
            if (!liveVideo.IsRecording)
            {
                liveVideo.IsRecording = true;
                var savedVideo = new SavedVideo
                {
                    Name = $"record-{DateTime.Today}"
                };
                liveVideo.SavedVideos.Add(savedVideo);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task StopRecording(string streamId)
        {
            var liveVideo = _dbContext.LiveVideos
                .Include(v => v.SavedVideos)
                .FirstOrDefault(v => v.StreamId == streamId);

            if (liveVideo.IsRecording)
            {
                var filename = _fileService.Move(streamId);

                var savedVideo = liveVideo.SavedVideos
                    .FirstOrDefault(v => v.IsRecordingComplete == false);
                liveVideo.IsRecording = false;
                savedVideo.IsRecordingComplete = true;
                savedVideo.VideoUrl = _config.RecordsUrl + filename;
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<SavedVideoModel> GetSavedVideos(string streamId)
        {
            var liveVideo = _dbContext.LiveVideos
                .Include(v => v.SavedVideos)
                .FirstOrDefault(v => v.StreamId == streamId);

            var videos = liveVideo.SavedVideos
                .Where(v => v.IsRecordingComplete == true)
                .Select(v => _mapper.Map<SavedVideoModel>(v))
                .ToList();

            return videos;
        }

        public Task DeleteRecord(int recordId)
        {
            throw new NotImplementedException();
        }
    }
}
