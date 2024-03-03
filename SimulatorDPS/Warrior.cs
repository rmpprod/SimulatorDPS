using SimulatorDPS.Models;

namespace SimulatorDPS
{
    public class Warrior : ICharacter
    {
        public Warrior(IWeapon weapon, int exp = 0, int hr = 0)
        {
            Weapon = weapon;
            Expertise = exp;
            HitRating = hr;
        }
        public string Name => "Warrior";
        public IWeapon Weapon { get; private set; }
        public int Expertise { get; private set; }
        public int HitRating { get; private set; }
        public double DPS()
        {
            return Weapon.Damage / Weapon.Speed;
        }
        public double ChanceToMiss()
        {
            double missChance = 8;

            if (HitRating != 0)
            {
                missChance -= Math.Truncate(100 * (HitRating / 30.7548)) / 100;
                if (missChance <= 0) return 0;
            }
            return missChance;
        }
        public double DodgeAndParryReduceChance()
        {
            double reduceChance = 0;

            if(Expertise != 0)
            {
                reduceChance = Math.Truncate(Expertise / 7.6886) * 0.25;
            }
            return reduceChance;
        }
    }
}
