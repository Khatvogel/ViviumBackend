using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.Extensions;
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
            // Dit is een test
            _deviceRepository = deviceRepository;
            _attemptRepository = attemptRepository;
            _attemptDeviceRepository = attemptDeviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _deviceRepository.GetListAsync();
            return Ok(JsonCycle.Fix(result));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Device device)
        {
            device.LastOnline = DateTime.Now;
            
            var responseDevice = await _deviceRepository.GetAsync(x => x.MacAddress == device.MacAddress);
            var lastAttempt = await _attemptRepository.GetListAsync();

            var response = new RegisterDeviceResponseViewModel(device);
            if (lastAttempt.Any())
            {
                var attemptDevice = await _attemptDeviceRepository.GetAsync(x =>
                    x.DeviceId == responseDevice.Id && x.AttemptId == lastAttempt.Last().Id);
                if (attemptDevice != null)
                {
                    response.Finished = attemptDevice.FinishedAt != null;
                    response.Started = attemptDevice.StartedAt != null;
                }
            }

            //update
            if (responseDevice.Id != 0)
            {
                responseDevice.LastOnline = DateTime.Now;
                responseDevice.Category = device.Category;
                responseDevice.Name = device.Name;
                response.Device = responseDevice;
                await _deviceRepository.UpdateAsync(responseDevice);
                return Ok(JsonCycle.Fix(response));
            }

            //post
            await _deviceRepository.AddAsync(device);
            return Ok(JsonCycle.Fix(response));
        }

        [HttpGet]
        [Route("finish")]
        public async Task<IActionResult> Finish(string macAddress)
        {
            var lastAttempt = await _attemptRepository.GetLastAsync();
            var currentDevice = await _deviceRepository.GetAsync(x => x.MacAddress == macAddress);
            if (lastAttempt == null || currentDevice.Id == 0)
            {
                return NoContent();
            }

            // Finish device
            var attemptDevice = lastAttempt.AttemptDevices.FirstOrDefault(x => x.DeviceId == currentDevice.Id);
            if (attemptDevice == null || attemptDevice.AttemptId == 0)
            {
                return NoContent();
            }

            attemptDevice.FinishedAt = DateTime.Now;
            await _attemptDeviceRepository.UpdateAsync(attemptDevice);

            var devicesOnOrder = (await _deviceRepository.GetListAsync(x => x.Order == currentDevice.Order))
                .Select(x => x.Id).ToList();

            var attemptDevicesFinished =
                await _attemptDeviceRepository.GetListAsync(x =>
                    devicesOnOrder.Contains(x.DeviceId) && x.FinishedAt != null && x.AttemptId == lastAttempt.Id);

            var devices = await _deviceRepository.GetListAsync(x => x.Order == currentDevice.Order + 1);
            // Is there nothing left to complete, they finished the game
            if (devicesOnOrder.Count == attemptDevicesFinished.Count)
            {
                if (devices.Count == 0)
                {
                    attemptDevice.Attempt.EndDate = DateTime.Now;
                    await _attemptRepository.UpdateAsync(attemptDevice.Attempt);
                    return Ok(JsonCycle.Fix(attemptDevice.Attempt));
                }

                // Are there devices that have to start after this one is finished? Start them here
                foreach (var nextDevice in devices)
                {
                    await _attemptDeviceRepository.AddAsync(new AttemptDevice
                    {
                        AttemptId = attemptDevice.Attempt.Id, DeviceId = nextDevice.Id,
                        StartedAt = DateTime.Now
                    });
                }
            }

            return Ok(JsonCycle.Fix(attemptDevice.Attempt));
        }
    }
}