using SimulatorDPS.Interfaces;

namespace SimulatorDPS.MechanicsWoW
{
    public class GetWhiteAttackHitTable
    {
        public WhiteAttackHitTable GetHitTable(ICharacter character, IBoss boss)
        {
            return new WhiteAttackHitTable
            {
                MissChance = character.ChanceToMiss(),
                DodgeChance = boss.DodgeChance > character.DodgeAndParryReduceChance() ? boss.DodgeChance - character.DodgeAndParryReduceChance() : 0,
                ParryChance = boss.ParryChance > character.DodgeAndParryReduceChance() ? boss.ParryChance - character.DodgeAndParryReduceChance() : 0,
                GlansingBlow = character.GlansingBLow,
                CriticalHit = character.CriticalHit
            };
        }
    }
}