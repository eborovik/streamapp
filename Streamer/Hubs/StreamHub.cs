using System.Diagnostics;
using System.Threading.Tasks;
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

        public async Task SendMessage(string user, string message)
        {
        }

        public void Register(string streamId)
        {
            Debug.WriteLine(Context.ConnectionId);
            _connectionManager.AddConnection(streamId, Context.ConnectionId);
        }
    }
}
