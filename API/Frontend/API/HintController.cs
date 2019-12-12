using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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

            var hint = await _hintRepository.AddAsync(new Hint {Attempt = attempt});

            var amount = attempt.Hints.Where(x => !x.Processed).ToList().Count;

            await _hintsHub.Clients.All.SendAsync("Create", amount, attempt.Hints);

            return Ok(JsonHelper.FixCycle(hint.Id));
        }

        [HttpGet]
        [Route("answer")]
        public async Task<IActionResult> GetAnswer(int id)
        {
            if (id < 1) return NotFound("No id given.");

            var hint = await _hintRepository.GetAsync(h => h.Id == id);

            if (hint == null) return NotFound("Hint with given id doesn't exist.");

            return Ok(JsonHelper.FixCycle(hint));
        }
    }
}