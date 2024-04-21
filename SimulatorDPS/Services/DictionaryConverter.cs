using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimulatorDPS.SpellSetter_s;

namespace SimulatorDPS.Services
{
    public class DictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, ISpellSetter>);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var dictionary = new Dictionary<string, ISpellSetter>();
            
            var jsonObject = JObject.Load(reader);
            foreach (var property in jsonObject.Properties())
            {
                ISpellSetter spellSetter;
                switch (property.Name)
                {
                    case "Warrior":
                        spellSetter = new WarriorSpellSetter();
                        break;
                    case "Rogue":
                        spellSetter = new RogueSpellSetter();
                        break;
                    default:
                        spellSetter = null;
                        break;
                }

                if (spellSetter != null)
                {
                    dictionary.Add(property.Name, spellSetter);
                }
            }

            return dictionary;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }
}
