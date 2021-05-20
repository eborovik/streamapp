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
        private readonly ISavedVideoService _savedVideoService;
        private readonly IHubContext<StreamHub> _hubContext;
        private readonly IHubConnectionManager _connectionManager;

        public LiveVideoController(ILiveVideoService videoService, 
            ISavedVideoService savedVideoService, IHubContext<StreamHub> hubContext, 
            IHubConnectionManager connectionManager)
        {
            _videoService = videoService;
            _savedVideoService = savedVideoService;
            _hubContext = hubContext;
            _connectionManager = connectionManager;
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

        [HttpGet("record/{id}")]
        public async Task<IActionResult> StartRecording(string id)
        {
            await _hubContext.Clients.Client(_connectionManager.GetConnection(id)).SendAsync("ReceiveMessage",
                "hello", "CRUELworld");
            await _savedVideoService.StartRecording(id);
            
            return Ok();
        }

        [HttpGet("stoprecord/{id}")]
        public async Task<IActionResult> StopRecording(string id)
        {
            await _savedVideoService.StopRecording(id);
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
