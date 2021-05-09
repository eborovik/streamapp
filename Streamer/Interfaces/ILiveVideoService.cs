using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface ILiveVideoService
    {
        public Task AddLiveVideo(LiveVideoModel video, string userEmail);
    }
}
