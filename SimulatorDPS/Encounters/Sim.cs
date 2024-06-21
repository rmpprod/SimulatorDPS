using SimulatorDPS.CalcStats;
using SimulatorDPS.ClassesWoW;
using SimulatorDPS.Core.Spells.Warrior;

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
            var charRotation = new WarriorRotation(new WarriorSpells(characterStats).warriorSpells);
            
            double lastTimeAttack = -1;
            double dmg = 0;
            
            for (double i = 0; i < 60; i+=0.1)
            {
                dmg += charRotation.Rotation(i).SpellDamage;
                if (lastTimeAttack + characterStats.MeleeStats.MeleeDamage.Speed < i || lastTimeAttack == -1)
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