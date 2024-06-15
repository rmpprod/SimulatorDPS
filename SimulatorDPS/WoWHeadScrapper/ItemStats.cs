using Newtonsoft.Json;

namespace SimulatorDPS.WoWHeadScrapper
{
    public class ItemStats
    {
        [JsonProperty("armor")]
        public int armor;

        [JsonProperty("str")]
        public int strength;

        [JsonProperty("agi")]
        public int agility;

        [JsonProperty("sta")]
        public int stamina;

        [JsonProperty("int")]
        public int intellect;

        [JsonProperty("spi")]
        public int spirit;

        [JsonProperty("mlecritstrkpct")]
        public int meleeCrit;

        [JsonProperty("rgdcritstrkpct")]
        public int rangeCrit;

        [JsonProperty("splcritstrkpct")]
        public int spellCrit;

        [JsonProperty("mlehitpct")]
        public int meleeHit;

        [JsonProperty("rgdhitpct")]
        public int rangeHit;

        [JsonProperty("splhitpct")]
        public int spellHit;

        [JsonProperty("mleatkpwr")]
        public int meleeAttackPower;

        [JsonProperty("rgdatkpwr")]
        public int rangedAttackPower;

        [JsonProperty("spldmg")]
        public int spellPower;

        [JsonProperty("splheal")]
        public int healPower;

        [JsonProperty("manargn")]
        public int mp5;

        [JsonProperty("mlespeed")]
        public double speed;

        [JsonProperty("dmgmax1")]
        public int maxDmg;

        [JsonProperty("dmgmin1")]
        public int minDmg;
    }
}