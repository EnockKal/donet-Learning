namespace VideoGameCharacterApi.Models.Service
{
    public interface IVideoGameCharacterService
    {
        Task<List<Character>> GetallCharactersAsync();

        Task<Character?> GetCharacterByIdAsync(int id);

        Task<Character> AddChacterByNameAsync(Character character);

        Task<bool> UpdateCharacterByNameAsync(int id, Character character);

        Task<bool> DeleteCharacterByIdAsync(int id);
    }
}
