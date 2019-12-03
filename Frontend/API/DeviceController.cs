using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.DTO;
using Frontend.Helpers;
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
            return Ok(JsonHelper.FixCycle(result));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Device device)
        {
            device.LastOnline = DateTime.Now;

            var currentDevice = await _deviceRepository.GetAsync(x => x.MacAddress == device.MacAddress);
            var currentGame = await _attemptRepository.GetLastAsync();

            var responseDto = new RegisterDeviceResponseDto(device);
            if (currentGame != null)
            {
                // Fetch status (started, finished) for this device in the current game
                var attemptDevice = await _attemptDeviceRepository.GetAsync(x =>
                    x.DeviceId == currentDevice.Id && x.AttemptId == currentGame.Id);

                // If it found an attempt device, overwrite the started and finished bool
                if (attemptDevice != null)
                {
                    responseDto.Finished = attemptDevice.FinishedAt != null;
                    responseDto.Started = attemptDevice.StartedAt != null;
                }
            }

            // Found a matching device, update it
            if (currentDevice.Id != 0)
            {
                currentDevice.LastOnline = DateTime.Now;
                currentDevice.Category = device.Category;
                currentDevice.Name = device.Name;
                responseDto.Device = currentDevice;
                await _deviceRepository.UpdateAsync(currentDevice);
                return Ok(JsonHelper.FixCycle(responseDto));
            }

            // No device found with this MAC address, make it
            await _deviceRepository.AddAsync(device);
            return Ok(JsonHelper.FixCycle(responseDto));
        }

        [HttpGet]
        [Route("finish")]
        public async Task<IActionResult> Finish(string macAddress)
        {
            var currentGame = await _attemptRepository.GetLastAsync();
            var currentDevice = await _deviceRepository.GetAsync(x => x.MacAddress == macAddress);
            if (currentGame == null || currentDevice.Id == 0)
            {
                return NoContent();
            }

            // Finish device
            var attemptDevice = currentGame.AttemptDevices.FirstOrDefault(x => x.DeviceId == currentDevice.Id);
            if (attemptDevice == null || attemptDevice.AttemptId == 0)
            {
                return NoContent();
            }

            attemptDevice.FinishedAt = DateTime.Now;
            await _attemptDeviceRepository.UpdateAsync(attemptDevice);

            // Fetch all devices on the same order that this device is trying to finish
            var devicesInOrder = (await _deviceRepository.GetListAsync(x => x.Order == currentDevice.Order))
                .Select(x => x.Id).ToList();

            // Get all the devices that are finished on this order in this attempt
            var attemptDevicesFinished =
                await _attemptDeviceRepository.GetListAsync(x =>
                    devicesInOrder.Contains(x.DeviceId) && x.FinishedAt != null && x.AttemptId == currentGame.Id);

            // Everything is finished on this order, either finish the game or start the next order
            if (devicesInOrder.Count == attemptDevicesFinished.Count)
            {
                var devices = await _deviceRepository.GetListAsync(x => x.Order == currentDevice.Order + 1);

                // If there are no devices in the next order, meaning there are no devices to be completed, finish the game
                if (devices.Count == 0)
                {
                    attemptDevice.Attempt.EndDate = DateTime.Now;
                    await _attemptRepository.UpdateAsync(attemptDevice.Attempt);
                    return Ok(JsonHelper.FixCycle(attemptDevice.Attempt));
                }

                // Are there devices that have to start after the current order? Start them here
                foreach (var nextDevice in devices)
                {
                    await _attemptDeviceRepository.AddAsync(new AttemptDevice
                    {
                        AttemptId = attemptDevice.Attempt.Id, DeviceId = nextDevice.Id,
                        StartedAt = DateTime.Now
                    });
                }
            }

            return Ok(JsonHelper.FixCycle(attemptDevice.Attempt));
        }
    }
}