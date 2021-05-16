using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streamer.Database;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Services
{
    public class LiveVideoService : ILiveVideoService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Config _config;

        public LiveVideoService(DatabaseContext dbContext, IMapper mapper, Config config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }  

        private async Task<LiveVideoModel> AddLiveVideo(LiveVideoModel video, string userEmail)
        {
            var streamId = video.StreamId == null ? Guid.NewGuid().ToString() : video.StreamId;
           
            var liveVideo = new LiveVideo
            {
                Name = video.Name,
                Url = $"{_config.StreamUrl}/{streamId}.m3u8",
                StreamId = streamId,
                Status = Status.Streaming
            };
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            user.LiveVideos.Add(liveVideo);
            await _dbContext.SaveChangesAsync();

            video.StreamId = streamId;
            video.Url = _config.StreamServerUrl + streamId;
            return video;
        }

        public async Task<LiveVideoModel> StartStream(LiveVideoModel video, string userEmail)
        {
            var liveVideo = _dbContext.LiveVideos.FirstOrDefault(v => v.StreamId == video.StreamId);
            if (liveVideo == null)
            {
                return await AddLiveVideo(video, userEmail);
            }
            liveVideo.Status = Status.Streaming;
            await _dbContext.SaveChangesAsync();

            video.Url = _config.StreamServerUrl + liveVideo.StreamId;
            return video;
        }

        public async Task StopStream(string streamId)
        {
            var video = _dbContext.LiveVideos.FirstOrDefault(v => v.StreamId == streamId);
            video.Status = Status.Stopped;
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<LiveVideoModel> GetLiveVideos(string userEmail)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail).Id;
            var videos = _dbContext.LiveVideos
                .Where(v => v.UserId == userId)
                .Select(v => _mapper.Map<LiveVideoModel>(v))
                .ToList();

            return videos;
        }
    }
}
