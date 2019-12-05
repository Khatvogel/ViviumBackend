using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Areas.Dashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAttemptDeviceRepository _repository;
        private readonly IAttemptRepository _attemptRepository;

        public IndexModel(ILogger<IndexModel> logger, IAttemptDeviceRepository repository, IAttemptRepository attemptRepository)
        {
            _logger = logger;
            _repository = repository;
            _attemptRepository = attemptRepository;
        }

        [BindProperty] public Attempt Attempt { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Attempt = await _attemptRepository.GetLastAsync();
            ViewData["Hints"] = Attempt.Hints;
            ViewData["ClassName"] = Attempt.Hints.Count > 0 ? "notification" : string.Empty;
            ViewData["HintsCount"] = Attempt.Hints.Count > 0 ? Attempt.Hints.Count : (object) null;
            
            return Page();
        }
    }
}