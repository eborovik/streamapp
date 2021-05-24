using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Streamer.Interfaces;

namespace Streamer.Hubs
{
    [AllowAnonymous]
    public class StreamHub : Hub
    {
        private readonly IHubConnectionManager _connectionManager;

        public StreamHub(IHubConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void Register(string streamId)
        {
            Debug.WriteLine(Context.ConnectionId);
            _connectionManager.AddConnection(streamId, Context.ConnectionId);
        }
    }
}
