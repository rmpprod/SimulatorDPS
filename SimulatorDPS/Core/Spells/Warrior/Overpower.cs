using SimulatorDPS.CalcStats;
using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Core.Spells.Warrior
{
    public class Overpower : Spell
    {
        public Overpower(CharacterStats characterStats, SpellOptions spellOptions) : base(characterStats, spellOptions)
        {
        }

        public override SpellResult Cast()
        {
            var plusDmg = 35;
            var weaponDmg = new NormalizedDamage().CalcNormalizedHit(Character);
            Console.WriteLine("OP");
            return new SpellResult
            {
                SpellDamage = plusDmg + weaponDmg
            };
        }
    }
}
