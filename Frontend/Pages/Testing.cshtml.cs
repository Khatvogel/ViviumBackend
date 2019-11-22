using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Pages
{
    public class TestingModel : PageModel
    {
        private ILogger<TestingModel> _logger;
        private readonly IConnectedDeviceRepository _repository;

        public TestingModel(ILogger<TestingModel> logger, IConnectedDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [BindProperty] public IReadOnlyList<ConnectedDevice> ConnectedDevices { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.Log(LogLevel.Error, "ERROR: api/testing");
            ConnectedDevices = await _repository.ListAllAsync();
            return Page(); 
        }
    }
}