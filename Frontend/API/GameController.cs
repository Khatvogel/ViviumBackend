using System;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var jsonResult = JsonConvert.SerializeObject(await _attemptRepository.GetListAsync(),
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(jsonResult);
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

            var device = lastAttempt.AttemptDevices.Find(x => x.DeviceMacAddress == macAddress);
            return Ok(device);
        }
    }
}