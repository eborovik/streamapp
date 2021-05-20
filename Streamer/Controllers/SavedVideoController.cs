using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SavedVideoController : ControllerBase
    {
        private readonly ISavedVideoService _videoService;

        public SavedVideoController(ISavedVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("getall/{id}")]
        public IEnumerable<SavedVideoModel> GetAll(string id)
        {
            return _videoService.GetSavedVideos(id);
        }
    }
}
