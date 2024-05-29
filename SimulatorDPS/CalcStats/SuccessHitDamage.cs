using SimulatorDPS.MechanicsWoW;

namespace SimulatorDPS.CalcStats
{
    public class SuccessHitDamage
    {
        private int _minEnd;
        private int _maxEnd;
        private MeleeAttackTable _meleeAT;
        public SuccessHitDamage(int minEnd, int maxEnd, MeleeAttackTable meleeAT)
        {
            _minEnd = minEnd;
            _maxEnd = maxEnd;
            _meleeAT = meleeAT;
        }

        public double SuccessHit()
        {
            var rnd = new RollOnHitService().RollOnHit();
            var rndDamage = new DamagePerHit().Hit(_minEnd, _maxEnd);
            if (rnd > _meleeAT.UnsuccessHitChance)
            {
                if (rnd > (_meleeAT.UnsuccessHitChance + 40 + _meleeAT.CritChance))
                {
                    return rndDamage;
                }
                else if (rnd > (_meleeAT.UnsuccessHitChance + 40))
                {
                    return rndDamage * 2;
                }
                else
                {
                    return rndDamage * _meleeAT.GlansingBlowPenalty;
                }
            }
            return 0;
        }
    }
}
