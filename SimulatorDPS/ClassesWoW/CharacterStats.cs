using SimulatorDPS.Core;
using SimulatorDPS.Core.Stats;
using SimulatorDPS.Core.Stats.Warrior;
using SimulatorDPS.WoWHeadScrapper;

namespace SimulatorDPS.ClassesWoW
{
    public class CharacterStats
    {
        public BaseStats BaseStats { get; set; }
        public MeleeStats MeleeStats { get; set; }
        private MeleeStats gearMeleeStats;

        public CharacterStats(Character character)
        {
            CalcBaseStats(character.Class, character.Race);
            var gearStats = new GearStats(new GearConverter(character.Gear).gearJson);
            CalcStats(gearStats.gearStats);
            CalcMeleeStats(character.Class);
        }

        private void CalcStats(Dictionary<string, ItemStats> gearStats)
        {
            gearMeleeStats = new MeleeStats
            {
                MeleeDamage = new MeleeDamage()
            };
            foreach (var item in gearStats)
            {
                BaseStats.Strength += item.Value.strength;
                BaseStats.Agility += item.Value.agility;
                BaseStats.Stamina += item.Value.stamina;
                BaseStats.Intellect += item.Value.intellect;
                BaseStats.Spirit += item.Value.spirit;

                gearMeleeStats.HitChance += item.Value.meleeHit;
                gearMeleeStats.CritChance += item.Value.meleeCrit;
                gearMeleeStats.MeleeAttackPower += item.Value.meleeAttackPower;
                
                if(item.Key == "MainHand")
                {
                    gearMeleeStats.MeleeDamage.MinDamage = item.Value.minDmg;
                    gearMeleeStats.MeleeDamage.MaxDamage = item.Value.maxDmg;
                    gearMeleeStats.MeleeDamage.Speed = item.Value.speed;
                }
            }
        }

        private void CalcBaseStats(CharacterClass characterClass, Race race)
        {
            var baseStats = characterClass switch
            {
                CharacterClass.Warrior => new WarriorBaseStats().warriorBaseStats[(int)race]
            };

            BaseStats = new BaseStats
            {
                Strength = baseStats[0],
                Agility = baseStats[1],
                Stamina = baseStats[2],
                Intellect = baseStats[3],
                Spirit = baseStats[4]
            };
        }

        private void CalcMeleeStats(CharacterClass characterClass)
        {
            var meleeStats = characterClass switch
            {
                CharacterClass.Warrior => new WarriorMeleeStats(BaseStats, gearMeleeStats).MeleeStats
            };
            MeleeStats = meleeStats;
        }
    }
}