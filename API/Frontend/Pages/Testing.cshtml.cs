using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Pages
{
    public class TestingModel : PageModel
    {
        private ILogger<TestingModel> _logger;
        private readonly IDeviceRepository _repository;

        public TestingModel(ILogger<TestingModel> logger, IDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [BindProperty] public IReadOnlyList<Device> ConnectedDevices { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.Log(LogLevel.Error, "ERROR: api/testing");
            ConnectedDevices = await _repository.GetListAsync();
            return Page(); 
        }
    }
}