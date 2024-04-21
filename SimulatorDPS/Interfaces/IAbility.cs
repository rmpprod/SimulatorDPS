namespace SimulatorDPS.Interfaces
{
    public interface IAbility
    {
        int Cost { get; }
        int Cooldown { get; }
        bool IsReady { get; }
        void Execute();
    }
}
