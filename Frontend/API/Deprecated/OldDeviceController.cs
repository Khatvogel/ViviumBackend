using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Frontend.API.Deprecated
{
    [ApiController]
    [Route("deprecated/device")]
    public class OldDeviceController : Controller
    {
        private readonly IFireBaseDeviceRepository _repository;

        public OldDeviceController(IFireBaseDeviceRepository fireBaseDeviceRepository, IHttpClientFactory httpClient)
        {
            _repository = fireBaseDeviceRepository;
            _repository.Initialize("Device");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetListAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Post(Device device)
        {
            _repository.PushAsync(device);
            return Ok(device);
        }

        [HttpPatch]
        [Route("ping")]
        public IActionResult Patch(Device device)
        {
            _repository.UpdateAsync(device);
            return Ok(device);
        }
    }
}