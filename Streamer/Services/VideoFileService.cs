using System;
using System.IO;
using Streamer.Interfaces;

namespace Streamer.Services
{
    public class VideoFileService : IFileService
    {
        private readonly Config _config;
        private const string FILE_EXT = ".flv";

        public VideoFileService(Config config)
        {
            _config = config;
        }

        public string Move(string streamId)
        {
            var id = Guid.NewGuid().ToString();
            var source = Path.Combine(_config.RecordsPath, $"{streamId}{FILE_EXT}");
            var dest = Path.Combine(_config.StoragePath, $"{id}{FILE_EXT}");

            File.Move(source, dest);

            return $"{id}{FILE_EXT}";
        }
    }
}
