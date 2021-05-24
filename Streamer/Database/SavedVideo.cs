using System;
using System.ComponentModel.DataAnnotations;

namespace Streamer.Database
{
    public class SavedVideo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartedTime { get; set; }
        public string VideoUrl { get; set; }
        public string FilePath { get; set; }
        public bool IsRecordingComplete { get; set; }

        public int LiveVideoId { get; set; }
        public LiveVideo LiveVideo { get; set; }
    }
}
