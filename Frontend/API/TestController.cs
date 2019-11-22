using System;
using System.Collections.Generic;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    /// <summary>
    /// Dit is een Test Api. Iedere API controller moet de volgende attributen hebben:
    /// ApiController en Route
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConnectedDeviceRepository _connectedDeviceRepository;

        public TestController(IConnectedDeviceRepository connectedDeviceRepository)
        {
            _connectedDeviceRepository = connectedDeviceRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"Test", "Test", "Test"};
        }

        [HttpPost]
        public IActionResult Create(string mac)
        {
            var game = new ConnectedDevice
            {
                MacAddress = mac,
                LastOnline = DateTime.Now,
                Name = "Test"
            };

            var result = _connectedDeviceRepository.AddAsync(game);
            return new JsonResult(result);
        }
    }
}