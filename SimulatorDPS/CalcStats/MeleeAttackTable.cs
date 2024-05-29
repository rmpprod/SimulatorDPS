using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.CalcStats
{
    public class MeleeAttackTable
    {
        public int MissChance { get; set; }
        public double DodgeChance { get; set; }
        public double GlansingBlowPenalty { get; set; }
        public double CritChance { get; set; }
        public double UnsuccessHitChance { get; set; }

        public MeleeAttackTable(CharacterStats characterStats)
        {
            CalcMissChance2HWeapon(characterStats.MeleeStats.HitChance, characterStats.MeleeStats.AttackRating);
            CalcDodgeChance(characterStats.MeleeStats.AttackRating);
            CalcGlansingBlowPenalty(characterStats.MeleeStats.AttackRating);
            CalcCritChance(characterStats.MeleeStats.CritChance, characterStats.MeleeStats.AttackRating);
            CalcUnsuccessHitChance();
        }

        public void CalcMissChance2HWeapon(int characterPercent, int attackRating)
        {
            double basicMissChance;
            if (attackRating > 304)
            {
                basicMissChance = Math.Round(5 + (315 - attackRating) * 0.1);
            }
            else
            {
                basicMissChance = Math.Round(7 + (315 - attackRating - 10) * 0.4);
            }

            MissChance = (int)basicMissChance > characterPercent ? (int)basicMissChance - characterPercent : 0;
        }
        
        public void CalcDodgeChance(int attackRating)
        {
            DodgeChance = 5 + (315 - attackRating) * 0.1;
        }

        public void CalcGlansingBlowPenalty(int attackRating)
        {
            double lowEnd = 1.3 - 0.05 * (315 - attackRating);
            lowEnd = lowEnd > 0.91 ? 0.91 : lowEnd;

            double highEnd = 1.2 - 0.03 * (315 - attackRating);
            highEnd = highEnd > 0.99 ? 0.99 : highEnd;
            highEnd = highEnd < 0.2 ? 0.2 : highEnd;

            GlansingBlowPenalty = (highEnd + lowEnd) / 2;
        }

        public void CalcCritChance(double characterPercent, int attackRating)
        {
            CritChance = characterPercent + (attackRating - 315) * 0.2;
        }

        public void CalcUnsuccessHitChance()
        {
            UnsuccessHitChance = MissChance + DodgeChance;
        }
    }
}
