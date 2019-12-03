using System.Threading.Tasks;
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

        public IndexModel(ILogger<IndexModel> logger, IAttemptDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [BindProperty] public DashboardViewModel DashboardViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var list = await _repository.GetListAsync();
            DashboardViewModel = new DashboardViewModel();
            return Page();
        }
    }
}