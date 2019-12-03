using System.Collections.Generic;
using Backend.Entities;

namespace Frontend.DTO
{
    public class AttemptDto
    {
        public IReadOnlyList<Attempt> Attempts { get; set; }
    }
}