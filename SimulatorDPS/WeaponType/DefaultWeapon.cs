using SimulatorDPS.Interfaces;

namespace SimulatorDPS.WeaponType
{
    public class DefaultWeapon : IWeapon
    {
        public DefaultWeapon()
        {
            Damage = 0;
            Speed = 0;
        }
        public double Damage { get; private set; }
        public double Speed { get; private set; }
    }
}
