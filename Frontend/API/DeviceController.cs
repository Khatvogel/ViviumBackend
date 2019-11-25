using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.API
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : Controller
    {
        private IConnectedDeviceRepository _repository;

        public DeviceController(IConnectedDeviceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _repository.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create(ConnectedDevice device)
        {
            var result = await _repository.AddAsync(device);
            return Ok(result);
        }
    }
}