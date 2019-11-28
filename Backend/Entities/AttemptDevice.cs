using System;

namespace Backend.Entities
{
    public class AttemptDevice
    {
        public int AttemptId { get; set; }
        public string DeviceMacAddress { get; set; }
        public bool Started { get; set; }
        public DateTime StartedAt { get; set; }
        public bool Finished { get; set; }
        public DateTime FinshedAt { get; set; }

        public Attempt Attempt { get; set; }
        public Device Device { get; set; }
    }
}