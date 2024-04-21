using SimulatorDPS.Interfaces;
using SimulatorDPS.Spells.Warrior;

namespace SimulatorDPS.SpellSetter_s
{
    public class WarriorSpellSetter : ISpellSetter
    {
        public void SetSpells(ICharacter charWow)
        {
            charWow.Abilities.Add(
                new MortalStrike());
        }
    }
}