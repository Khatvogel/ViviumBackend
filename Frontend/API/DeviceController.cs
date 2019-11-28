using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IAttemptRepository _attemptRepository;
        private readonly IAttemptDeviceRepository _attemptDeviceRepository;

        public DeviceController(IDeviceRepository deviceRepository, IAttemptRepository attemptRepository,
            IAttemptDeviceRepository attemptDeviceRepository)
        {
            _deviceRepository = deviceRepository;
            _attemptRepository = attemptRepository;
            _attemptDeviceRepository = attemptDeviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _deviceRepository.GetListAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post(Device device)
        {
            device.LastOnline = DateTime.UtcNow.AddHours(1);
            var result = await _deviceRepository.GetAsync(device.MacAddress);
            var lastAttempt = await _attemptRepository.GetListAsync();

            var response = new RegisterDeviceResponseViewModel(device);
            if (lastAttempt.Any())
            {
                var attemptDevice = await _attemptDeviceRepository.GetAsync(x =>
                    x.DeviceMacAddress == device.MacAddress && x.AttemptId == lastAttempt.Last().Id);
                
                response.Finished = attemptDevice.Finished;
                response.Started = attemptDevice.Started;
            }

            //update
            if (result != null)
            {
                _deviceRepository.Detach(result);
                await _deviceRepository.UpdateAsync(device);
                return Ok(response);
            }

            //post
            await _deviceRepository.AddAsync(device);
            return Ok(response);
        }
    }
}