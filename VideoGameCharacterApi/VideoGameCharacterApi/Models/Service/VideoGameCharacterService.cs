
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;

namespace VideoGameCharacterApi.Models.Service
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        private readonly AppDbContext context;

        public VideoGameCharacterService(AppDbContext context)
        {
            this.context = context;
        }
        // Data to work with
        static List<Character> character = new List<Character>
        {
            new Models.Character { Id = 1, Name = "Mario", Game = "Super Mario Bros", Role = "Hero"},
            new Models.Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero"},
            new Models.Character { Id = 3, Name = "Boweser", Game = "Super Mario Bros", Role = "Hero"},
            new Models.Character { Id = 4, Name = "Zelda", Game = "The Legend of Zelda", Role = "Pricess"}
        };

        public Task<Character> AddChacterByNameAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetallCharactersAsync()
            => await context.Characters.ToListAsync();

        public async Task<Character?> GetCharacterByIdAsync(int id)
            => await context.Characters.FindAsync(id);

        public Task<bool> UpdateCharacterByNameAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
