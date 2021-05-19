using System.Threading.Tasks;

namespace Streamer.Interfaces
{
    public interface ISavedVideoService
    {
        Task StartRecording(string streamId);
        Task StopRecording(string streamId);
        Task DeleteRecord(int recordId);
    }
}
