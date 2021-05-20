using AutoMapper;
using Streamer.Database;
using Streamer.Models;

namespace Streamer
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<LiveVideo, LiveVideoModel>();
            CreateMap<SavedVideo, SavedVideoModel>();
        }
    }
}
