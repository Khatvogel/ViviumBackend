using System;
using System.Collections.Generic;

namespace Backend.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastOnline { get; set; }
        public bool Enabled { get; set; }
        public int Order { get; set; }
    }
}