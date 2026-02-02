
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Models.Service
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponse> AddChacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterByIdAsync(int id)
        {
            var characterToDelete = await context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            if (characterToDelete is null)
                return false;

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CharacterResponse>> GetallCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
            => await context.Characters
                                    .Where(c => c.Id == id)
                                    .Select(c => new CharacterResponse
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        Game = c.Game,
                                        Role = c.Role
                                    }).FirstOrDefaultAsync();

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var ExistingCharacter = await context.Characters.FirstAsync(c => c.Id == id);
            if (ExistingCharacter is null)
                return false;

            ExistingCharacter.Name = character.Name;
            ExistingCharacter.Game = character.Game;
            ExistingCharacter.Role = character.Role;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
