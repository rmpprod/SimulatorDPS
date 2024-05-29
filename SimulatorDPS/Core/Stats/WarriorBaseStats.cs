namespace SimulatorDPS.Core.Stats
{
    public class WarriorBaseStats
    {
        public List<int[]> warriorBaseStats;
        public WarriorBaseStats()
        {
            warriorBaseStats = new List<int[]>
            {
                human,
                dwarf,
                gnome,
                nightElf,
                orc,
                undead,
                tauren,
                troll
            };
        }

        private int[] human =
        {
            120,
            80,
            110,
            30,
            47
        };

        private int[] dwarf =
        {
            122,
            76,
            113,
            29,
            44
        };

        private int[] gnome =
        {
            115,
            83,
            109,
            35,
            45
        };

        private int[] nightElf =
        {
            117,
            85,
            109,
            30,
            45
        };

        private int[] orc =
        {
            123,
            77,
            112,
            27,
            48
        };

        private int[] undead =
        {
            119,
            78,
            111,
            28,
            50
        };

        private int[] tauren =
        {
            125,
            75,
            112,
            25,
            47
        };

       private int[] troll =
        {
            121,
            82,
            111,
            26,
            46
        };
    }
}