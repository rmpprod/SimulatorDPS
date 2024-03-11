namespace SimulatorDPS.Interfaces
{
    public interface IBoss
    {
        string Name { get; }
        double HealthPoints { get; }
        double DodgeChance { get; }
        double ParryChance { get; }
    }
}
