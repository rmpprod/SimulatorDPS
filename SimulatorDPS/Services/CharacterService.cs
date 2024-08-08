using Microsoft.EntityFrameworkCore;

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
            var character = _dbContext.Characters.Include(c => c.Gear).Where(c => c.Name == name).FirstOrDefault();
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
        
        public DeleteCharacterModel Delete(DeleteCharacterModel model)
        {
            var currentCharacter = _dbContext.Characters.FirstOrDefault(c => c.Id == model.Id);

            if (currentCharacter != null)
            {
                _dbContext.Characters.Remove(currentCharacter);
                _dbContext.SaveChanges();
            }

            return model;
        }

        public List<CharacterModel> GetAllUserCharacters()
        public string Sim(string name)
        {
            var character = _dbContext.Characters.Include(c => c.Gear).Where(c => c.Name == name).FirstOrDefault();
            var responce = new Sim(character).ToString();
            return responce;
        }
    }
}