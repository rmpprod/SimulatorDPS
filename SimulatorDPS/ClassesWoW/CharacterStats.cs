using SimulatorDPS.Core.Stats;

namespace SimulatorDPS.ClassesWoW
{
    public class CharacterStats
    {
        public CharacterStats(Character character)
        {
            BaseStats = new BaseStatsSetter().Set(character.Class, character.Race);
            MeleeStats = new MeleeStats
            {
                MeleeDamage = new MeleeDamage
                {
                    MinDamage = 273,
                    MaxDamage = 360,
                    Speed = 3.60
                },
                AttackRating = 305,
                HitChance = 0,
                CritChance = 4,
                MeleeAttackPower = 400,
            };
        }

        public BaseStats BaseStats {  get; set; }
        public MeleeStats MeleeStats { get; set; }
    }
}