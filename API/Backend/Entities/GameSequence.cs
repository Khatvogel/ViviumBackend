namespace Backend.Entities
{
    public class GameSequence
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public int Order { get; set; }
        
        public virtual Device Device { get; set; }
    }
}