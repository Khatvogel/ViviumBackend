using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : Controller
    {
        private readonly IFireBaseDeviceRepository _fireBaseDeviceRepository;
        
        public DeviceController(IFireBaseDeviceRepository fireBaseDeviceRepository)
        {
            _fireBaseDeviceRepository = fireBaseDeviceRepository;
            _fireBaseDeviceRepository.Initialize("Device");
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var result = await _fireBaseDeviceRepository.GetListAsync();
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create(ConnectedDevice device)
        {
            var result = await _fireBaseDeviceRepository.PushAsync(device);
            return Ok(result);
        }
    }
}