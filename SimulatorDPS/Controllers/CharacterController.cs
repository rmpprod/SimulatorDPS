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
        private GearService _gearService;
        public CharacterController(CharacterService characterService, GearService gearService)
        {
            _characterService = characterService;
            _gearService = gearService;
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
        [HttpGet("sim")]
        public IResult GetSim(string name)
        {
            var simDamage = _characterService.Sim(name);
            return Results.Ok(simDamage);
        }
        [HttpPost("creategear")]
        public IResult CreateGear(GearModel gearModel)
        {
            var gear = _gearService.Create(gearModel);
            return Results.Ok(gear);
        }
        [HttpPatch("updategear")]
        public IResult UpdateGear(GearModel gearModel)
        {
            var gear = _gearService.Update(gearModel);
            return Results.Ok(gear);
        }
    }
}