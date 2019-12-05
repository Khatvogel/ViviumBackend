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

        private readonly IAttemptRepository _attemptRepository;

        public IndexModel(IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var attempt = await _attemptRepository.GetLastAsync();
            ViewData["Hints"] = attempt.Hints;
            ViewData["ClassName"] = attempt.Hints.Count > 0 ? "notification" : string.Empty;
            ViewData["HintsCount"] = attempt.Hints.Count > 0 ? attempt.Hints.Count : (object) null;
            
            return Page();
        }
    }
}