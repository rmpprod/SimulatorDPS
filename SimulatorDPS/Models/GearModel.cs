namespace SimulatorDPS.Models
{
    public class GearModel
    {
        public int? Id { get; set; }
        public int? CharacterId { get; set; }

        public int? Head { get; set; }
        public int? Neck { get; set; }
        public int? Shoulders { get; set; }
        public int? Back { get; set; }
        public int? Chest { get; set; }
        public int? Wrist { get; set; }
        public int? Hands { get; set; }
        public int? Waist { get; set; }
        public int? Legs { get; set; }
        public int? Feet { get; set; }
        public int? Ring1 { get; set; }
        public int? Ring2 { get; set; }
        public int? Trinket1 { get; set; }
        public int? Trinket2 { get; set; }

        public int? MainHand { get; set; }
        public int? OffHand { get; set; }
        public int? Ranged { get; set; }
    }
}
