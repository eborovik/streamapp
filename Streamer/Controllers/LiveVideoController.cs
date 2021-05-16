using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public LiveVideoController(ILiveVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Add(LiveVideoModel video)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var streamData = await _videoService.StartStream(video, userEmail);
            return Ok(streamData);
        }

        [HttpGet("stop/{id}")]
        public async Task<IActionResult> Add(string id)
        {
            await _videoService.StopStream(id);
            return Ok();
        }

        [HttpGet("getall")]
        public IEnumerable<LiveVideoModel> Get()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return _videoService.GetLiveVideos(userEmail);
        }
    }
}
