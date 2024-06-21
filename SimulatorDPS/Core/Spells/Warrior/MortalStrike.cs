using SimulatorDPS.CalcStats;
using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Core.Spells.Warrior
{
    public class MortalStrike : Spell
    {
        public MortalStrike(CharacterStats characterStats, SpellOptions spellOptions) : base(characterStats, spellOptions)
        {
        }

        public override SpellResult Cast()
        {
            var plusDmg = 160;
            var weaponDmg = new NormalizedDamage().CalcNormalizedHit(Character);
            Console.WriteLine("MS");
            return new SpellResult
            {
                SpellDamage = plusDmg + weaponDmg
            };
        }
    }
}
