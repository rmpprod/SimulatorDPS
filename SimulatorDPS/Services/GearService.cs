using Microsoft.EntityFrameworkCore;
using SimulatorDPS.ClassesWoW;
using SimulatorDPS.Core.Gear;
using SimulatorDPS.DataBaseEF;
using SimulatorDPS.Models;

namespace SimulatorDPS.Services
{
    public class GearService
    {
        private ApplicationContext _dbContext;
        public GearService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GearModel Create(GearModel gearModel)
        {
            var character = _dbContext.Characters.FirstOrDefault(c => c.Id == gearModel.CharacterId);
            var gear = new Gear
            {
                Head = gearModel.Head,
                Neck = gearModel.Neck,
                Shoulders = gearModel.Shoulders,
                Back = gearModel.Back,
                Chest = gearModel.Chest,
                Wrist = gearModel.Wrist,
                Hands = gearModel.Hands,
                Waist = gearModel.Waist,
                Legs = gearModel.Legs,
                Feet = gearModel.Feet,
                Ring1 = gearModel.Ring1,
                Ring2 = gearModel.Ring2,
                Trinket1 = gearModel.Trinket1,
                Trinket2 = gearModel.Trinket2,
                MainHand = gearModel.MainHand,
                OffHand = gearModel.OffHand,
                Ranged = gearModel.Ranged,
                Character = character
            };
            _dbContext.Gears.Add(gear);
            _dbContext.SaveChanges();

            gearModel.Id = gear.Id;
            return gearModel;
        }
    }
}
