using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Core.Spells.Warrior
{
    public class WarriorSpells
    {
        public List<Spell> warriorSpells;
        public WarriorSpells(CharacterStats characterStats)
        {
            warriorSpells = new List<Spell>();

            warriorSpells.Add(new MortalStrike(characterStats,
                new SpellOptions
                {
                    Cooldown = 6,
                    Cost = 30
                }));

            warriorSpells.Add(new Overpower(characterStats,
                new SpellOptions
                {
                    Cooldown = 5,
                    Cost = 5
                }));
        }
    }
}