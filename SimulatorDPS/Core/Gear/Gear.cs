using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Core.Gear
{
    public class Gear
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }
        public Character? Character { get; set; }

        public MainHand? MainHand { get; set; }
    }
}