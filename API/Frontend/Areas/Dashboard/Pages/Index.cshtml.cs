using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces.Repositories;
using Frontend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Areas.Dashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAttemptRepository _attemptRepository;
        private readonly IHintRepository _hintRepository;

        public IndexModel(IAttemptRepository attemptRepository, IHintRepository hintRepository)
        {
            _attemptRepository = attemptRepository;
            _hintRepository = hintRepository;
        }

        [BindProperty]
        public HintDto Hint { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var attempt = await _attemptRepository.GetLastAsync();
            var hints = attempt.Hints.Where(x => !x.Processed).ToList();
            ViewData["Hints"] = hints;
            ViewData["ClassName"] = hints.Count > 0 ? "notification" : string.Empty;
            ViewData["HintsCount"] = hints.Count > 0 ? hints.Count : (object) null;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(HintDto hint)
        {
            if (!ModelState.IsValid) return Page();
            
            var updateHint = await _hintRepository.GetAsync(x => x.Id == hint.Id);
            updateHint.Description = hint.Description;
            updateHint.Processed = true;
            
            await _hintRepository.UpdateAsync(updateHint);

            return Redirect("~/");
        }
    }
}