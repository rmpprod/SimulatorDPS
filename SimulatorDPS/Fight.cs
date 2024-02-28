using SimulatorDPS.Models;

namespace SimulatorDPS
{
    public class Fight
    {
        public double Duration { get; set; }
        public int BossHealth { get; set; }
        public IClass Class { get; set; }
    }
}
