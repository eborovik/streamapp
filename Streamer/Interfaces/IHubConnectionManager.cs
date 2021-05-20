namespace Streamer.Interfaces
{
    public interface IHubConnectionManager
    {
        string GetConnection(string streamId);
        void AddConnection(string streamId, string connectionId);
        void RemoveConnection(string streamId);
    }
}
