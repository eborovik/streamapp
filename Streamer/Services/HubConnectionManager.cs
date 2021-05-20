using System.Collections.Generic;
using Streamer.Interfaces;

namespace Streamer.Services
{
    public class HubConnectionManager : IHubConnectionManager
    {
        private Dictionary<string, string> _connections = new Dictionary<string, string>();
        public string GetConnection(string streamId)
        {
            return _connections[streamId];
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
            throw new System.NotImplementedException();
        }
    }
}
