using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Models.Service
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetallCharactersAsync();

        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        Task<CharacterResponse> AddChacterByNameAsync(Character character);

        Task<bool> UpdateCharacterByNameAsync(int id, Character character);

        Task<bool> DeleteCharacterByIdAsync(int id);
    }
}
