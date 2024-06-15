namespace SimulatorDPS.Core.Stats.Warrior
{
    public class WarriorMeleeStats
    {
        public MeleeStats MeleeStats { get; set; }
        public WarriorMeleeStats(BaseStats baseStats, MeleeStats gear)
        {
            CalcWarriorMeleeStats(baseStats, gear);
        }

        private void CalcWarriorMeleeStats(BaseStats baseStats, MeleeStats gear)
        {
            var attackPower = 180 + (baseStats.Strength * 2 - 20) + gear.MeleeAttackPower;
            var critChance = baseStats.Agility / 20 + gear.CritChance;
            var meleeDamage = new MeleeDamage
            {
                MinDamage = (int)Math.Round(gear.MeleeDamage.MinDamage + (gear.MeleeDamage.Speed * attackPower / 14)),
                MaxDamage = (int)Math.Round(gear.MeleeDamage.MaxDamage + (gear.MeleeDamage.Speed * attackPower / 14)),
                Speed = gear.MeleeDamage.Speed
            };
            MeleeStats = new MeleeStats
            {
                MeleeDamage = meleeDamage,
                AttackRating = 300,
                CritChance = critChance,
                HitChance = gear.HitChance,
                MeleeAttackPower = attackPower
            };
        }
    }
}