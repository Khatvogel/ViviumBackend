using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IFireBaseGameRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IFireBaseGameRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _repository.Initialize("Game");
        }
        
        [BindProperty] public List<Game> Games { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Games = await _repository.GetAsync();
            return Page();
        }
    }
}