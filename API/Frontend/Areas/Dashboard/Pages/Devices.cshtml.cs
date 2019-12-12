using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Areas.Dashboard.Pages
{
    public class DevicesModel : PageModel
    {
        private readonly ILogger<DevicesModel> _logger;
        private readonly IDeviceRepository _repository;

        public DevicesModel(ILogger<DevicesModel> logger, IDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [BindProperty] public IReadOnlyList<Device> ConnectedDevices { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ConnectedDevices = await _repository.GetListAsync();
            return Page();
        }
    }
}