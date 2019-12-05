using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Frontend.Services.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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

            var hint = new Hint
            {
                Attempt = attempt
            };

            await _hintRepository.AddAsync(hint);
            await _hintsHub.Clients.All.SendAsync("Create", attempt.Hints.Count);
            return Ok("Je hebt om een hint gevraagd. Even geduld a.u.b.");
        }
    }
}