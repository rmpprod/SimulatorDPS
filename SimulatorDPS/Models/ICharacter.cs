namespace SimulatorDPS.Models
{
    public interface ICharacter
    {
        string Name { get; }
        double DPS();
        double ChanceToMiss();
        double DodgeAndParryReduceChance();
        IWeapon Weapon { get; }
    }
}
