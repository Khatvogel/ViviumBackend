using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("games")]
    public class GameController : Controller
    {
        private readonly IAttemptRepository _attemptRepository;
        private readonly IAttemptDeviceRepository _attemptDeviceRepository;

        public GameController(IAttemptRepository attemptRepository, IAttemptDeviceRepository attemptDeviceRepository)
        {
            _attemptRepository = attemptRepository;
            _attemptDeviceRepository = attemptDeviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _attemptRepository.GetListAsync());
        }

        [HttpGet]
        [Route("start")]
        public async Task<IActionResult> Start()
        {
            await _attemptRepository.AddAsync(new Attempt {StartDate = DateTime.Now});
            return Ok(new {success = true});
        }

        [HttpGet]
        [Route("finish")]
        public async Task<IActionResult> Finish(string macAddress)
        {
            var lastAttempt = await _attemptRepository.GetLastAsync();
            if (lastAttempt == null)
            {
                return NoContent();
            }

//            await _attemptDeviceRepository.AddAsync(new AttemptDevice
//            {
//                DeviceMacAddress = "84:0D:8E:8D:46:7E",
//                AttemptId = lastAttempt.Id,
//                Started = true,
//                StartedAt = DateTime.Now
//            });

            var device = lastAttempt.AttemptDevices.Find(x => x.DeviceMacAddress == macAddress);
            return Ok(device);
        }
    }
}