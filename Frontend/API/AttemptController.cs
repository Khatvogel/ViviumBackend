using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("attempts")]
    public class AttemptController : Controller
    {
        private readonly IAttemptRepository _attemptRepository;
        private readonly IAttemptDeviceRepository _attemptDeviceRepository;
        private readonly IDeviceRepository _deviceRepository;

        public AttemptController(IAttemptRepository attemptRepository, IAttemptDeviceRepository attemptDeviceRepository,
            IDeviceRepository deviceRepository)
        {
            _attemptRepository = attemptRepository;
            _attemptDeviceRepository = attemptDeviceRepository;
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonCycle.Fix(await _attemptRepository.GetListAsync()));
        }

        [HttpGet]
        [Route("start")]
        public async Task<IActionResult> Start()
        {
            var attempt = await _attemptRepository.AddAsync(new Attempt {StartDate = DateTime.Now});
            var devices = await _deviceRepository.GetListAsync();
            if (devices.Count == 0)
            {
                return NoContent();
            }

            var orderNumber = devices.OrderBy(x => x.Order).First().Order;
            foreach (var device in devices.Where(x => x.Order == orderNumber))
            {
                await _attemptDeviceRepository.AddAsync(new AttemptDevice
                {
                    AttemptId = attempt.Id, DeviceId = device.Id,
                    StartedAt = DateTime.Now
                });
            }
            
            return Ok(JsonCycle.Fix(attempt));
        }
    }
}