namespace SimulatorDPS.MechanicsWoW
{
    public class RollOnHitService
    {
        public double RollOnHit()
        {
            var rnd = new Random();
            var rndNum = rnd.NextDouble() * (100 - 0.01) + 0.01;
            rndNum = Math.Truncate(100 * rndNum) / 100;
            return rndNum;
        }
    }
}
