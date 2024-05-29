namespace SimulatorDPS.Core
{
    public enum SpellType
    {
        Buff = 0,
        Damage = 1
    }
    public class SpellConfig
    {
        public SpellType SpellType { get; set; }
        public double Cooldown { get; set; }
        public double Cost { get; set; }
        public double LastUsedTime { get; set; }
    }
}