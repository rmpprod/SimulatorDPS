using Microsoft.AspNetCore.Mvc;

namespace SimulatorDPS.Controllers
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
                Character = new Warrior(new Axe(2200, 3.27), 200, 170),
                Boss = new Boss("Anubis", 3000000)
            };

            var fightResult = fight.FightSimulation();
            return fightResult.ToString();
        }
    }
}