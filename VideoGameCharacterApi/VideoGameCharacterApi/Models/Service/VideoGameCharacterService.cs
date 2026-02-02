
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Models.Service
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        private readonly AppDbContext context;

        public VideoGameCharacterService(AppDbContext context)
        {
            this.context = context;
        }

        public Task<CharacterResponse> AddChacterByNameAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CharacterResponse>> GetallCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
            => await context.Characters
                                    .Where(c => c.Id == id)
                                    .Select(c => new CharacterResponse
                                    {
                                        Name = c.Name,
                                        Game = c.Game,
                                        Role = c.Role
                                    }).FirstOrDefaultAsync();

        public Task<bool> UpdateCharacterByNameAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
