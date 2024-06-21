using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.CalcStats
{
    public class NormalizedDamage
    {
        public double CalcNormalizedHit(CharacterStats characterStats)
        {
            var dmgPH = new DamagePerHit().Hit(characterStats.MeleeStats.MeleeDamage.MinDamage, characterStats.MeleeStats.MeleeDamage.MaxDamage);
            var dmg = dmgPH + (3.3 * characterStats.MeleeStats.MeleeAttackPower / 14);
            return dmg;
        }
    }
}
