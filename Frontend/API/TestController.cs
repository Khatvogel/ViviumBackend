using System;
using System.Collections.Generic;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.API
{
    /// <summary>
    /// Dit is een Test Api. Iedere API controller moet de volgende attributen hebben:
    /// ApiController en Route
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public TestController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"Test", "Test", "Test"};
        }

        [HttpPost]
        public IActionResult Create(int id)
        {
            var game = new Game
            {
                Id = id,
                Finished = false,
                LastOnline = DateTime.Now,
                MacAddress = Guid.NewGuid().ToString(),
                Name = "Test"
            };

            var result = _gameRepository.AddAsync(game);
            return new JsonResult(result);
        }
    }
}