namespace SimulatorDPS.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        double DPS();
        double ChanceToMiss();
        double DodgeAndParryReduceChance();
        double GlansingBLow { get; }
        double CriticalHit { get; }
        IWeapon Weapon { get; }
    }
}
