using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Streamer.Hubs
{
    [AllowAnonymous]
    public class StreamHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            
        }
    }
}
