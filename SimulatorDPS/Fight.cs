using SimulatorDPS.Models;

namespace SimulatorDPS
{
    public class Fight
    {
        public double Duration { get; set; }
        public ICharacter Character { get; set; }
        public IBoss Boss { get; set; }
        public HitTable GetHitTable()
        {
            return new HitTable
            {
                MissChance = Character.ChanceToMiss(),
                DodgeChance = Boss.DodgeChance > Character.DodgeAndParryReduceChance() ? Boss.DodgeChance - Character.DodgeAndParryReduceChance() : 0,
                ParryChance = Boss.ParryChance > Character.DodgeAndParryReduceChance() ? Boss.ParryChance - Character.DodgeAndParryReduceChance() : 0
            };
        }
        public double RollOnHit()
        {
            var rnd = new Random();
            var rndNum = rnd.NextDouble() * (100 - 0.01) + 0.01;
            rndNum = Math.Truncate(100 * rndNum) / 100;
            return rndNum;
        }
        public FightResult FightSimulation()
        {
            var fightResult = new FightResult() { Duration = Duration};
            var numbersOfAttacks = (int)Math.Truncate(Duration / Character.Weapon.Speed);
            var hitTable = GetHitTable();
            var loseHitChance = hitTable.LoseHitChance();

            for(int i = numbersOfAttacks; i > 0; i--)
            {
                var rndNum = RollOnHit();
                if(rndNum > loseHitChance)
                {
                    fightResult.TotalDamage += Character.Weapon.Damage;
                }
            }
            return fightResult;
        }
    }
}