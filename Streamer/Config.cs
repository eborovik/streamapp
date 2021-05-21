namespace Streamer
{
    public class Config
    {
        public string ConnectionString { get; set; }
        public string JwtTokenKey { get; set; }
        public string StreamServerUrl { get; set; }
        public string StreamUrl { get; set; }
        public string RecordStreamUrl { get; set; }
        public string RecordsPath { get; set; }
        public string StoragePath { get; set; }
        public string RecordsUrl { get; set; }
    }
}
