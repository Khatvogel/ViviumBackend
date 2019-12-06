using System.ComponentModel.DataAnnotations;

namespace Frontend.DTO
{
    public class HintDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}