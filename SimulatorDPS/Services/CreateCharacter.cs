using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimulatorDPS.ClassesWoW;
using SimulatorDPS.SpellSetter_s;
using SimulatorDPS.WeaponType;

namespace SimulatorDPS.Services
{
    [ApiController]
    [Route("[controller]")]
    public class CreateCharacter
    {
        [HttpGet]
        public Character GetCharacter([FromServices] ISpellSetter spellSetter, string name, int dmg = 0, double speed = 0)
        {
            var charWow = new Character(spellSetter, name, new Axe(dmg, speed));
            charWow.DownloadSpells();

            using (var writer = new StreamWriter("DataBaseTXT/DB.json", true))
            {
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.Converters.Add(new WeaponConverter());
                var json = JsonConvert.SerializeObject(charWow, settings);
                writer.WriteLine(json);
                Console.WriteLine("finaly saved");
            }
            return charWow;
        }
    }
}