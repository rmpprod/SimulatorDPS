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

        public GearModel Update(GearModel gearModel)
        {
            var currentGear = _dbContext.Gears.FirstOrDefault(g => g.CharacterId == gearModel.CharacterId);

            if (currentGear != null)
            {
                currentGear.Head = gearModel.Head ?? currentGear.Head;
                currentGear.Neck = gearModel.Neck ?? currentGear.Neck;
                currentGear.Shoulders = gearModel.Shoulders ?? currentGear.Shoulders;
                currentGear.Back = gearModel.Back ?? currentGear.Back;
                currentGear.Chest = gearModel.Chest ?? currentGear.Chest;
                currentGear.Wrist = gearModel.Wrist ?? currentGear.Wrist;
                currentGear.Hands = gearModel.Hands ?? currentGear.Hands;
                currentGear.Waist = gearModel.Waist ?? currentGear.Waist;
                currentGear.Legs = gearModel.Legs ?? currentGear.Legs;
                currentGear.Feet = gearModel.Feet ?? currentGear.Feet;
                currentGear.Ring1 = gearModel.Ring1 ?? currentGear.Ring1;
                currentGear.Ring2 = gearModel.Ring2 ?? currentGear.Ring2;
                currentGear.Trinket1 = gearModel.Trinket1 ?? currentGear.Trinket1;
                currentGear.Trinket2 = gearModel.Trinket2 ?? currentGear.Trinket2;
                currentGear.MainHand = gearModel.MainHand ?? currentGear.MainHand;
                currentGear.OffHand = gearModel.OffHand ?? currentGear.OffHand;
                currentGear.Ranged = gearModel.Ranged ?? currentGear.Ranged;
                _dbContext.Gears.Update(currentGear);
                _dbContext.SaveChanges();
            }
            
            return gearModel;
        }

        public DeleteGearModel Delete(DeleteGearModel model)
        {
            var currentGear = _dbContext.Gears.FirstOrDefault(g => g.Id == model.Id);

            if (currentGear != null)
            {
                _dbContext.Gears.Remove(currentGear);
                _dbContext.SaveChanges();
            }

            return model;
        }
    }
}
