using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : Controller
    {
        public FirebaseController(IFireBaseDeviceRepository fireBaseDeviceRepository)
        {
            _fireBaseDeviceRepository = fireBaseDeviceRepository;
            _fireBaseDeviceRepository.Initialize("Game");
        }

        private readonly IFireBaseDeviceRepository _fireBaseDeviceRepository;

        [HttpGet]
        [Route("devices")]
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