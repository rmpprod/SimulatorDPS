using Microsoft.AspNetCore.Mvc;
using SimulatorDPS.Models;
using SimulatorDPS.Services;

namespace SimulatorDPS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController
    {
        private CharacterService _characterService;
        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IResult Get(string name)
        {
            var character = _characterService.Get(name);
            return Results.Ok(character);
        }
        [HttpPost]
        public IResult Create(CharacterModel characterModel)
        {
            var newCharacter = _characterService.Create(characterModel);
            return Results.Ok(newCharacter);
        }
        [HttpGet]
        [Route("Sim")]
        public IResult GetSim(string name)
        {
            var simDamage = _characterService.Sim(name);
            return Results.Ok(simDamage);
        }
    }
}