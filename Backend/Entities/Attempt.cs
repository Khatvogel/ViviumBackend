using System;

namespace Backend.Entities
{
    public class Attempt
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}