using System.Collections.Generic;
using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface ILiveVideoService
    {
        Task AddLiveVideo(LiveVideoModel video, string userEmail);
        IEnumerable<LiveVideoModel> GetLiveVideos(string userEmail);
    }
}
