using SimulatorDPS.Interfaces;
using SimulatorDPS.Services;

namespace SimulatorDPS.SpellSetter_s
{
    public class DefaultSpellSetter : ISpellSetter
    {
        public void SetSpells(ICharacter charWow)
        {
            var dictionaryDB = new GetDictionaryDB().GetDDB();
            dictionaryDB.TryGetValue(charWow.Name, out var spellSetter);
            spellSetter.SetSpells(charWow);
        }
    }
}
