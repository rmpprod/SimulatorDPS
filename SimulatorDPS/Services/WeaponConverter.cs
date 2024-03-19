using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimulatorDPS.Interfaces;
using SimulatorDPS.WeaponType;

namespace SimulatorDPS.Services
{
    public class WeaponConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IWeapon);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var weaponObject = JToken.Load(reader);
            double damage = weaponObject.Value<double>("Damage");
            double speed = weaponObject.Value<double>("Speed");
            return new Axe(damage, speed);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var weapon = (IWeapon)value;
            JObject weaponObject = new JObject
            {
                { "Damage", weapon.Damage },
                { "Speed", weapon.Speed }
            };
            weaponObject.WriteTo(writer);
        }
    }
}
