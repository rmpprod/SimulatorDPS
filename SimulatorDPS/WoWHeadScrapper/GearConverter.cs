using HtmlAgilityPack;

using ScrapySharp.Extensions;

using SimulatorDPS.Core.Gear;

namespace SimulatorDPS.WoWHeadScrapper
{
    public class GearConverter
    {
        public Dictionary<string, string> gearJson;
        
        public GearConverter(Gear gear)
        {
            gearJson = new Dictionary<string, string>();
            ItemsConvertToJson(gear);
        }

        private void ItemsConvertToJson(Gear gear)
        {
            var web = new HtmlWeb();

            foreach(var id in gear.GetType().GetProperties())
            {
                if(id.PropertyType == typeof(int?) && (int)id.GetValue(gear) != 0)
                {
                    var document = web.Load($"https://www.wowhead.com/classic/?item={id.GetValue(gear)}");
                    var node = document.DocumentNode.CssSelect("script").FirstOrDefault(x => x.InnerText.StartsWith("\nWH.Gatherer.addData(3"));

                    var indexJsonEquip = node.InnerText.IndexOf("jsonequip") + 11;
                    var indexAttainable = node.InnerText.IndexOf("attainable") - 2;
                    var diff = indexAttainable - indexJsonEquip;
                    var textJson = node.InnerText.Substring(indexJsonEquip, diff);

                    gearJson.Add(id.Name, textJson);
                }
            }
        }
    }
}
