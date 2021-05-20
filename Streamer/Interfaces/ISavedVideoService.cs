using System.Collections.Generic;
using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface ISavedVideoService
    {
        Task StartRecording(string streamId);
        Task StopRecording(string streamId);
        Task DeleteRecord(int recordId);
        IEnumerable<SavedVideoModel> GetSavedVideos(string streamId);
    }
}
