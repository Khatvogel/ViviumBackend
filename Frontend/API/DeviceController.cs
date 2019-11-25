using System;
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
        private readonly IConnectedDeviceRepository _repository;

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
        public async Task<IActionResult> Post(ConnectedDevice device)
        {
            device.LastOnline = DateTime.UtcNow.AddHours(1);
            var result = await _repository.GetAsync(device.MacAddress);
            
            //update
            if (result != null)
            {
                _repository.Detach(result);
                await _repository.UpdateAsync(device);
                return Ok("Device already exists.");
            }

            //post
            await _repository.AddAsync(device);
            return Ok("Device successfully added.");
        }
    }
}