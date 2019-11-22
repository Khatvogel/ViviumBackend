using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API.Deprecated
{
    [ApiController]
    [Route("deprecated/device")]
    public class OldDeviceController : Controller
    {
        public OldDeviceController(IConnectedDeviceRepository repository)
        {
            _repository = repository;
        }

        private readonly IConnectedDeviceRepository _repository;

        [HttpGet]
        public IActionResult Get(string mac)
        {
            var result = _repository.GetAsync(mac);
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Post(ConnectedDevice device)
        {
            _repository.AddAsync(device);
            return Ok(device);
        }

        [HttpPatch]
        [Route("ping")]
        public IActionResult Patch(ConnectedDevice device)
        {
            _repository.UpdateAsync(device);
            return Ok(device);
        }
    }
}