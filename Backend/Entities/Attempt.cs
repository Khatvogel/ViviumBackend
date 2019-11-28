using System;
using System.Collections.Generic;

namespace Backend.Entities
{
    public class Attempt
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<Device> Devices { get; set; }
        public virtual List<AttemptDevice> AttemptDevices { get; set; }
    }
}