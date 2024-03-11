using SimulatorDPS.Interfaces;

namespace SimulatorDPS.Encounters
{
    public class Boss : IBoss
    {
        public Boss(string name, double hp, double dodgeChance = 6.5, double parryChance = 14)
        {
            Name = name;
            HealthPoints = hp;
            DodgeChance = dodgeChance;
            ParryChance = parryChance;
        }
        public string Name { get; private set; }
        public double HealthPoints { get; private set; }
        public double DodgeChance { get; private set; }
        public double ParryChance { get; private set; }
    }
}
