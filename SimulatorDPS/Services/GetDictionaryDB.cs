using Newtonsoft.Json;
using SimulatorDPS.SpellSetter_s;

namespace SimulatorDPS.Services
{
    public class GetDictionaryDB
    {
        public Dictionary<string, ISpellSetter> GetDDB()
        {
            using (var reader = new StreamReader("DataBaseTXT/DictionaryDB.json"))
            {
                var jsonText = reader.ReadToEnd();
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.Converters.Add(new DictionaryConverter());
                var dict = JsonConvert.DeserializeObject<Dictionary<string, ISpellSetter>>(jsonText, settings);
                return dict;
            }
        }
    }
}