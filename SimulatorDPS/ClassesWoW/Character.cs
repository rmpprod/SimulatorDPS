using SimulatorDPS.Core;
using SimulatorDPS.Core.Gear;

namespace SimulatorDPS.ClassesWoW
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CharacterClass Class { get; set; }
        public Race Race { get; set; }

        public Gear? Gear { get; set; }
    }
}