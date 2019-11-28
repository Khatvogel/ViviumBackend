using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class Device
    {
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }

        public int AttemptId { get; set; }
        public Attempt Attempt { get; set; }

        public virtual List<AttemptDevice> AttemptDevices { get; set; }
    }
}