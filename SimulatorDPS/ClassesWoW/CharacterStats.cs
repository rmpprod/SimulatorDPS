using SimulatorDPS.Core.Stats;
using SimulatorDPS.WoWHeadScrapper;

namespace SimulatorDPS.ClassesWoW
{
    public class CharacterStats
    {
        public BaseStats BaseStats { get; set; }
        public MeleeStats MeleeStats { get; set; }

        public CharacterStats(Character character)
        {
            var gearStats = new GearStats(new GearConverter(character.Gear).gearJson);
            var baseStats = new BaseStatsSetter().Set(character.Class, character.Race);
            var meleeStats = new MeleeStats
            {
                MeleeDamage = new MeleeDamage(),
                AttackRating = 305,
                HitChance = 0,
                CritChance = 4,
                MeleeAttackPower = 400,
            };
            CalcStats(gearStats.gearStats, baseStats, meleeStats);
        }

        private void CalcStats(Dictionary<string, ItemStats> gearStats, BaseStats baseStats, MeleeStats meleeStats)
        {
            foreach (var item in gearStats)
            {
                baseStats.Strength += item.Value.strength;
                baseStats.Agility += item.Value.agility;
                baseStats.Stamina += item.Value.stamina;
                baseStats.Intellect += item.Value.intellect;
                baseStats.Spirit += item.Value.spirit;

                meleeStats.HitChance += item.Value.meleeHit;
                meleeStats.CritChance += item.Value.meleeCrit;
                meleeStats.MeleeAttackPower += item.Value.meleeAttackPower;
                
                if(item.Key == "MainHand")
                {
                    meleeStats.MeleeDamage.MinDamage = item.Value.minDmg;
                    meleeStats.MeleeDamage.MaxDamage = item.Value.maxDmg;
                    meleeStats.MeleeDamage.Speed = item.Value.speed;
                }
            }
            BaseStats = baseStats;
            MeleeStats = meleeStats;
        }
    }
}