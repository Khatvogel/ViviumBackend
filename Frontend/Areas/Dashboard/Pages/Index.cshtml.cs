using System.Linq;
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
            var hints = attempt.Hints.Where(x => !x.Processed).ToList();
            ViewData["Hints"] = hints;
            ViewData["ClassName"] = hints.Count > 0 ? "notification" : string.Empty;
            ViewData["HintsCount"] = hints.Count > 0 ? hints.Count : (object) null;

            return Page();
        }
    }
}