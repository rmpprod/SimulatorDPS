namespace SimulatorDPS.Core.Spells.Warrior
{
    public class MortalStrike
    {
        public SpellResult RegisterMortalStrike()
        {
            var spellConfig = new SpellConfig
            {
                SpellType = SpellType.Damage,
                Cooldown = 6,
                Cost = 30
            };
            return new SpellResult();
        }
    }
}