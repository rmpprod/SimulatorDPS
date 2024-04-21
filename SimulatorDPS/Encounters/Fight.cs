using SimulatorDPS.MechanicsWoW;
using SimulatorDPS.Interfaces;

namespace SimulatorDPS.Encounters
{
    public class Fight
    {
        public double Duration { get; set; }
        public ICharacter Character { get; set; }
        public IBoss Boss { get; set; }
        public FightResult FightSimulation()
        {
            var fightResult = new FightResult() { Duration = Duration };
            var numbersOfAttacks = (int)Math.Truncate(Duration / Character.Weapon.Speed);
            var hitTable = new GetWhiteAttackHitTable().GetHitTable(Character, Boss);
            var loseHitChance = hitTable.LoseHitChance();

            for (int i = numbersOfAttacks; i > 0; i--)
            {
                var rndNum = new RollOnHitService().RollOnHit();
                if (rndNum > loseHitChance)
                {
                    if (rndNum > (loseHitChance + hitTable.GlansingBlow + hitTable.CriticalHit))
                    {
                        fightResult.TotalDamage += Character.Weapon.Damage;
                        continue;
                    }
                    else if (rndNum > (loseHitChance + hitTable.GlansingBlow))
                    {
                        fightResult.TotalDamage += Character.Weapon.Damage * 2;
                        continue;
                    }
                    fightResult.TotalDamage += Character.Weapon.Damage * 0.75;
                }
            }
            return fightResult;
        }
    }
}