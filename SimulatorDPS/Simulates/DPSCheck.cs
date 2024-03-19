using Microsoft.AspNetCore.Mvc;
using SimulatorDPS.Encounters;
using SimulatorDPS.Services;

namespace SimulatorDPS.Simulates
{
    [ApiController]
    [Route("[controller]")]
    public class DPSCheck
    {
        [HttpGet]
        public string GetSimulationDPS(string name)
        {
            var fight = new Fight
            {
                Duration = 120,
                Character = new CharacterFinder().FindCharacter(name),
                Boss = new Boss("Anubis", 3000000)
            };

            var fightResult = fight.FightSimulation();
            return fightResult.ToString();
        }
    }
}