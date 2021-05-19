using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Streamer.Hubs;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LiveVideoController : ControllerBase
    {
        private readonly ILiveVideoService _videoService;
        private readonly IHubContext<StreamHub> _hubContext;

        public LiveVideoController(ILiveVideoService videoService, IHubContext<StreamHub> hubContext)
        {
            _videoService = videoService;
            _hubContext = hubContext;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Add(LiveVideoModel video)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var streamData = await _videoService.StartStream(video, userEmail);
            return Ok(streamData);
        }

        [HttpGet("stop/{id}")]
        public async Task<IActionResult> StopStream(string id)
        {
            await _videoService.StopStream(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("hub")]
        public async Task sendmsg()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "hello", "world");
            //return Ok();
        }

        [HttpGet("getall")]
        public IEnumerable<LiveVideoModel> GetAll()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return _videoService.GetLiveVideos(userEmail);
        }
    }
}
