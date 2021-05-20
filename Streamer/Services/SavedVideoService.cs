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

        public SavedVideoService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
                var savedVideo = liveVideo.SavedVideos
                    .FirstOrDefault(v => v.IsRecordingComplete == false);
                liveVideo.IsRecording = false;
                savedVideo.IsRecordingComplete = true;
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
