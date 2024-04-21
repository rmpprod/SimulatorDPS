using SimulatorDPS.Interfaces;

namespace SimulatorDPS.Spells.Warrior
{
    public class MortalStrike : IAbility
    {
        public int Cost { get; private set; } = 30;
        public int Cooldown { get; private set; } = 6;
        public bool IsReady { get; private set; } = true;
        public int BaseDamage { get; private set; }
        public int ExtraDamage { get; private set; } = 418;
        public void Execute()
        {
            IsReady = false;
        }
    }
}