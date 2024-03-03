namespace SimulatorDPS
{
    public class HitTable
    {
        public double MissChance { get; set; }
        public double DodgeChance { get; set; }
        public double ParryChance { get; set; }
        public double LoseHitChance()
        {
            return MissChance + DodgeChance + ParryChance;
        }
        public double OrdinaryHitChance()
        {
            return 100 - (MissChance + DodgeChance + ParryChance);
        }
    }
}