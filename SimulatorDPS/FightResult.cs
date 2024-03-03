namespace SimulatorDPS
{
    public class FightResult
    {
        public double Duration { get; set; }
        public double TotalDamage { get; set; }
        public override string ToString()
        {
            var result = $"Общее время боя = {Duration}, Итоговый урон = {TotalDamage}";
            return result;
        }
    }
}
