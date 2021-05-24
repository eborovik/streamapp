using System.Collections.Generic;
using Streamer.Interfaces;

namespace Streamer.Services
{
    public class HubConnectionManager : IHubConnectionManager
    {
        private Dictionary<string, string> _connections = new Dictionary<string, string>();
        public string GetConnection(string streamId)
        {
            string connectionId;
            _connections.TryGetValue(streamId, out connectionId);
            return connectionId;
        }

        public void AddConnection(string streamId, string connectionId)
        {
            if (_connections.ContainsKey(streamId))
            {
                _connections[streamId] = connectionId;
                return;
            }
            _connections.Add(streamId, connectionId);
        }

        public void RemoveConnection(string streamId)
        {
            _connections.Remove(streamId);
        }
    }
}
