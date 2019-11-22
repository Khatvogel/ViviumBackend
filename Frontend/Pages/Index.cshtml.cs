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
        private readonly IFireBaseDeviceRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IFireBaseDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _repository.Initialize("Device");
        }
        
        [BindProperty] public List<ConnectedDevice> ConnectedDevices { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ConnectedDevices = await _repository.GetListAsync();
            return Page();
        }
    }
}