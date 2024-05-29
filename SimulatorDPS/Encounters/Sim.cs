using SimulatorDPS.CalcStats;
using SimulatorDPS.ClassesWoW;

namespace SimulatorDPS.Encounters
{
    public class Sim
    {
        private double _dmg;
        public Sim(Character character)
        {
            CalcSim(character);
        }

        public void CalcSim(Character character)
        {
            var characterStats = new CharacterStats(character);
            var meleeAT = new MeleeAttackTable(characterStats);
            var success = new SuccessHitDamage(characterStats.MeleeStats.MeleeDamage.MinDamage, characterStats.MeleeStats.MeleeDamage.MaxDamage, meleeAT);
            
            double lastTimeAttack = 0;
            double dmg = 0;
            
            for (int i = 0; i < 60; i++)
            {
                if (lastTimeAttack + characterStats.MeleeStats.MeleeDamage.Speed > i)
                {
                    dmg += success.SuccessHit();
                    lastTimeAttack = i;
                }
                else { continue; }
            }

            _dmg = dmg;
        }

        public override string ToString()
        {
            return $"Общий урон за 60 секунд составил: {_dmg}";
        }
    }
}