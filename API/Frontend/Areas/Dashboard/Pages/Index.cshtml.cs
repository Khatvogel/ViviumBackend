using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
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

        private List<Hint> _hints;

        public async Task<IActionResult> OnGetAsync()
        {
            var attempt = await _attemptRepository.GetLastAsync();

            _hints = attempt == null ? new List<Hint>() : attempt.Hints.Where(x => !x.Processed).ToList();

            ViewData["Hints"] = _hints;
            ViewData["ClassName"] = _hints.Count > 0 ? "notification" : string.Empty;
            ViewData["HintsCount"] = _hints.Count > 0 ? _hints.Count : (object) null;

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