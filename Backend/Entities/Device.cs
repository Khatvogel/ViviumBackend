using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class  Device
    {
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastOnline { get; set; }
    }
}