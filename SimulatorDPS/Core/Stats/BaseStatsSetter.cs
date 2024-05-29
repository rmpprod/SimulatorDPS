namespace SimulatorDPS.Core.Stats
{
    public class BaseStatsSetter
    {
        public BaseStats Set(CharacterClass characterClass, Race race)
        {
            var baseStats = characterClass switch
            {
                CharacterClass.Warrior => new WarriorBaseStats().warriorBaseStats[(int)race]
            };

            return new BaseStats
            {
                Strength = baseStats[0],
                Agility = baseStats[1],
                Stamina = baseStats[2],
                Intellect = baseStats[3],
                Spirit = baseStats[4]
            };
        }
    }
}