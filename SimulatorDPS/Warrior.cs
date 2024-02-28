using SimulatorDPS.Models;

namespace SimulatorDPS
{
    public class Warrior : IClass
    {
        public Warrior(IWeapon weapon)
        {
            Weapon = weapon;
        }
        public string Name => "Warrior";
        public IWeapon Weapon { get; private set; }
        public double DPS()
        {
            return Weapon.Damage / Weapon.Speed;
        }
    }
}
