namespace SimulatorDPS.Core.Gear
{
    public class MainHand
    {
        public int Id { get; set; }

        public int GearId { get; set; }
        public Gear? Gear { get; set; }

        public int? MinDamage { get; set; }
        public int? MaxDamage { get; set; }
        public double? Speed { get; set; }
    }
}
