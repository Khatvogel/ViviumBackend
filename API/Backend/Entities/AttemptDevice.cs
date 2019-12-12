using System;

namespace Backend.Entities
{
    public class AttemptDevice
    {
        public int AttemptId { get; set; }
        public virtual Attempt Attempt { get; set; }
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
        
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}