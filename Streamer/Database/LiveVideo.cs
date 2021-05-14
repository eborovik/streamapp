﻿using System.ComponentModel.DataAnnotations;

namespace Streamer.Database
{
    public class LiveVideo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
