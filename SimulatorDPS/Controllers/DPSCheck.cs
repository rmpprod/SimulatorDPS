using Microsoft.AspNetCore.Mvc;

namespace SimulatorDPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DPSCheck
    {
        [HttpGet]
        public double Get()
        {
            var fight = new Fight
            {
                Duration = 120,
                BossHealth = 3000000,
                Class = new Warrior(new Axe(2200, 3.27))
            };

            return fight.Class.DPS() * fight.Duration;
        }
    }
}