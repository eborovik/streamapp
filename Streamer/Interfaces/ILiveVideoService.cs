using System.Collections.Generic;
using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface ILiveVideoService
    {
        Task<LiveVideoModel> StartStream(LiveVideoModel video, string userEmail);
        IEnumerable<LiveVideoModel> GetLiveVideos(string userEmail);
        Task StopStream(string streamId);
        Task DeleteStream(string streamId);
    }
}
