namespace SimulatorDPS.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        List<IAbility> Abilities { get; }
        double GlansingBLow { get; }
        double CriticalHit { get; }
        IWeapon Weapon { get; }
        
        //Methods
        double DPS();
        double ChanceToMiss();
        double DodgeAndParryReduceChance();
    }
}
