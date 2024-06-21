using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Core.Spells
{
    public abstract class Spell
    {
        public CharacterStats Character { get; set; } 
        public SpellOptions SpellOptions { get; set; }
        public double LastCast { get; set; }
        public Spell(CharacterStats characterStats, SpellOptions spellOptions)
        {
            Character = characterStats;
            SpellOptions = spellOptions;
            LastCast = -1;
        }
        public abstract SpellResult Cast();
    }
}