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
        public DateTime FinishedAt { get; set; }

        public virtual Attempt Attempt { get; set; }
        public virtual Device Device { get; set; }
    }
}