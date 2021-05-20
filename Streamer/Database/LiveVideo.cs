using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamer.Database
{
    public class LiveVideo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string StreamId { get; set; }
        public string Status { get; set; }
        public bool IsRecording { get; set; }
        public ICollection<SavedVideo> SavedVideos { get; set; } = new List<SavedVideo>();

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public static class Status
    {
        public static string Streaming = nameof(Streaming);
        public static string Stopped = nameof(Stopped);
    }
}
