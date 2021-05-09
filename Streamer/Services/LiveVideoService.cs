using System;
using System.Linq;
using System.Threading.Tasks;
using Streamer.Database;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Services
{
    public class LiveVideoService : ILiveVideoService
    {
        private readonly DatabaseContext _dbContext;

        public LiveVideoService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }  

        public async Task AddLiveVideo(LiveVideoModel video, string userEmail)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            var liveVideo = new LiveVideo{Name = video.Name};
            user.LiveVideos.Add(liveVideo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
