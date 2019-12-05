namespace Backend.Entities
{
    public class Hint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Processed { get; set; }
        public string Description { get; set; }
        public Attempt Attempt { get; set; }
    }
}