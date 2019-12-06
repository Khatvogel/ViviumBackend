﻿using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.Helpers;
using Frontend.Services.SignalR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Frontend.API
{
    [ApiController]
    [Route("hint")]
    public class HintController : Controller
    {
        private readonly IAttemptRepository _repository;
        private readonly IHubContext<HintsHub> _hintsHub;
        private readonly IHintRepository _hintRepository;

        public HintController(IAttemptRepository repository, IHubContext<HintsHub> hintsHub,
            IHintRepository hintRepository)
        {
            _repository = repository;
            _hintsHub = hintsHub;
            _hintRepository = hintRepository;
        }

        [HttpGet]
        [Route("new")]
        public async Task<IActionResult> New()
        {
            var attempt = await _repository.GetLastAsync();
            if (attempt == null) return NotFound();

            await _hintRepository.AddAsync(new Hint {Attempt = attempt});

            var amount = attempt.Hints.Select(x => !x.Processed).ToList().Count;

            await _hintsHub.Clients.All.SendAsync("Create", amount, attempt.Hints);

            return Ok("Je hebt om een hint gevraagd. Even geduld a.u.b.");
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromForm]Hint model)
        {
            if (string.IsNullOrEmpty(model.Description)) return Problem("No description");
            
            var hint = await _hintRepository.GetAsync(x => x.Id == model.Id);
            hint.Description = model.Description;
            hint.Processed = true;
            
            await _hintRepository.UpdateAsync(hint);
            
            return Redirect("Dashboard");
        }
    }
}