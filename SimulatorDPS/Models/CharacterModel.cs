using SimulatorDPS.Core;

namespace SimulatorDPS.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CharacterClass Class { get; set; }
        public Race Race { get; set; }
    }
}