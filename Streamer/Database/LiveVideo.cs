using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamer.Database
{
    public class LiveVideo
    {
        [Key]
        public int Id { get; set; }
    }
}
