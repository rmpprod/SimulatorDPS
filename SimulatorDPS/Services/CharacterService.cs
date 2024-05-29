using SimulatorDPS.ClassesWoW;
using SimulatorDPS.DataBaseEF;
using SimulatorDPS.Encounters;
using SimulatorDPS.Models;

namespace SimulatorDPS.Services
{
    public class CharacterService
    {
        private ApplicationContext _dbContext;
        public CharacterService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CharacterModel Get(string name)
        {
            var character = _dbContext.Characters.FirstOrDefault(c => c.Name == name);
            return new CharacterModel
            {
                Id = character.Id,
                Name = character.Name,
                Class = character.Class,
                Race = character.Race
            };
        }

        public CharacterModel Create(CharacterModel characterModel)
        {
            var character = new Character
            {
                Name = characterModel.Name,
                Class = characterModel.Class,
                Race = characterModel.Race
            };
            _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();

            characterModel.Id = character.Id;
            return characterModel;
        }

        public string Sim(string name)
        {
            var character = _dbContext.Characters.FirstOrDefault(c => c.Name == name);
            var responce = new Sim(character).ToString();
            return responce;
        }
    }
}