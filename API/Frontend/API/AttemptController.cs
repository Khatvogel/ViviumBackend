using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.Helpers;
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
            return Ok(JsonHelper.FixCycle(await _attemptRepository.GetListAsync()));
        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> Status()
        {
            var devicesToFinishDev = await _deviceRepository.GetListAsync(x => x.Enabled);
            var lastAttempt = await _attemptRepository.GetLastAsync();
            if (lastAttempt?.AttemptDevices == null)
            {
                return NoContent();
            }

            var devicesToFinish = devicesToFinishDev.Count;
            var finishedDevices = lastAttempt.AttemptDevices.Count(x => x.FinishedAt != null);
            var finishedPercentage = Convert.ToDouble(finishedDevices) / Convert.ToDouble(devicesToFinish) * 100;
            return Ok(new {finishedPercentage = Convert.ToInt16(finishedPercentage), finishedDevices, devicesToFinish});
        }
        
        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> Current()
        {
            return Ok(JsonHelper.FixCycle(await _attemptRepository.GetLastAsync()));
        }

        [HttpGet]
        [Route("start")]
        public async Task<IActionResult> Start()
        {
            var attempt = await _attemptRepository.AddAsync(new Attempt {StartDate = DateTime.Now});
            var devices = await _deviceRepository.GetListAsync(x => x.Enabled);
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
            
            return Ok(JsonHelper.FixCycle(attempt));
        }
    }
}