using SimulatorDPS.Interfaces;

namespace SimulatorDPS.WeaponType
{
    public class Axe : IWeapon
    {
        public Axe(double damage, double speed)
        {
            Damage = damage;
            Speed = speed;
        }
        public double Damage { get; private set; }
        public double Speed { get; private set; }
    }
}
