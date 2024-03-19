using Newtonsoft.Json;
using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Services
{
    public class CharacterFinder
    {
        public Character FindCharacter(string name)
        {
            using (var reader = new StreamReader("DataBaseTXT/DB.json"))
            {
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.Converters.Add(new WeaponConverter());
                string jsonLine;
                while ((jsonLine = reader.ReadLine()) != null)
                {
                    var charWow = JsonConvert.DeserializeObject<Character>(jsonLine, settings);
                    if (charWow.Name == name)
                    {
                        return charWow;
                    }
                }
            }
            return null;
        }
    }
}