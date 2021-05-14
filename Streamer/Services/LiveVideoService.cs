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

        public LiveVideoService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }  

        public async Task AddLiveVideo(LiveVideoModel video, string userEmail)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            var liveVideo = new LiveVideo{Name = video.Name};
            user.LiveVideos.Add(liveVideo);
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
