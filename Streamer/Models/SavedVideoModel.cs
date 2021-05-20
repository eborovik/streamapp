using System;

namespace Streamer.Models
{
    public class SavedVideoModel
    {
        public string Name { get; set; }
        public DateTime StartedTime { get; set; }
        public string DeviceName { get; set; }
        public string VideoUrl { get; set; }
        public string FilePath { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
