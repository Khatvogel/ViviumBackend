using System.Threading.Tasks;
using Backend.Interfaces.Firebase;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        public PingController(IFireBaseGameRepository repository)
        {
            _repository = repository;
        }

        private readonly IFireBaseGameRepository _repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _repository.Initialize("Game");
            var data = await _repository.GetAsync();

            return new JsonResult(data);
        }
    }
}