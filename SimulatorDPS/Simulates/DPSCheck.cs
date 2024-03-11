using Microsoft.AspNetCore.Mvc;
using SimulatorDPS.ClassesWoW;
using SimulatorDPS.Encounters;
using SimulatorDPS.WeaponType;

namespace SimulatorDPS.Simulates
{
    [ApiController]
    [Route("[controller]")]
    public class DPSCheck
    {
        [HttpGet]
        public string Get()
        {
            var fight = new Fight
            {
                Duration = 120,
                Character = new Warrior(new Axe(2200, 3.27)),
                Boss = new Boss("Anubis", 3000000)
            };

            var fightResult = fight.FightSimulation();
            return fightResult.ToString();
        }
    }
}