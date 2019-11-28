using System.Collections.Generic;
using Backend.Entities;

namespace Frontend.ViewModels
{
    public class AttemptViewModel
    {
        public IReadOnlyList<Attempt> Attempts { get; set; }
    }
}