using Newtonsoft.Json;

namespace SimulatorDPS.WoWHeadScrapper
{
    public class GearStats
    {
        public Dictionary<string, ItemStats> gearStats;
        public GearStats(Dictionary<string, string> gearJson)
        {
            gearStats = new Dictionary<string, ItemStats>();
            ParseGearStats(gearJson);
        }

        private void ParseGearStats(Dictionary<string, string> gearJson)
        {
            foreach(var item in gearJson)
            {
                var itemStats = JsonConvert.DeserializeObject<ItemStats>(item.Value);
                gearStats.Add(item.Key, itemStats);
            }
        }
    }
}
