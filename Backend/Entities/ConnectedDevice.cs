using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    /// <summary>
    /// Deze klasse dient als base klasse voor iedere bedenkbare
    /// apparaat/game voor in de Escape room.
    /// </summary>
    public class  ConnectedDevice
    {
        public string Category { get; set; }
        public DateTime LastOnline { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
    }
}