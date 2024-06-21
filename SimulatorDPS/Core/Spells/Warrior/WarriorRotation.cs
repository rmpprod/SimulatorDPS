namespace SimulatorDPS.Core.Spells.Warrior
{
    public class WarriorRotation
    {
        private List<Spell> warriorSpells;
        private double lastCast;
        public WarriorRotation(List<Spell> spells)
        {
            warriorSpells = spells;
            lastCast = -1;
        }

        public SpellResult Rotation(double nowTime)
        {
            if (CheckGCD(nowTime))
            {
                foreach (Spell spell in warriorSpells)
                {
                    if (spell.LastCast + spell.SpellOptions.Cooldown < nowTime || spell.LastCast == -1)
                    {
                        Console.WriteLine(nowTime);
                        spell.LastCast = nowTime;
                        lastCast = nowTime;
                        return spell.Cast();
                    }
                }
            }
            return new SpellResult { SpellDamage = 0 };
        }
        
        private bool CheckGCD(double nowTime)
        {
            if(lastCast != -1)
            {
                return nowTime - lastCast >= 1.5;
            }
            return true;
        }
    }
}
