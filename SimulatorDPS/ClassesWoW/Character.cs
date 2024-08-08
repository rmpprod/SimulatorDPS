using SimulatorDPS.Core;
using SimulatorDPS.Core.Gear;
using SimulatorDPS.Data;

namespace SimulatorDPS.ClassesWoW
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CharacterClass Class { get; set; }
        public Race Race { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public Gear? Gear { get; set; }
    }
}