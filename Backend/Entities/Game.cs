using System;

namespace Backend.Entities
{
    /// <summary>
    /// Deze klasse dient als base klasse voor iedere bedenkbare
    /// game voor in de Escape room.
    /// </summary>
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public string MacAddress { get; set; }
        public DateTime LastOnline { get; set; }
    }
}