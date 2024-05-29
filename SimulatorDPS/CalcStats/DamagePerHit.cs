namespace SimulatorDPS.CalcStats
{
    public class DamagePerHit
    {
        public int Hit(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}