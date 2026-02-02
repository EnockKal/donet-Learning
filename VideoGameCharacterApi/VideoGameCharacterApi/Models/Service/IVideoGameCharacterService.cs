using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Models.Service
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetallCharactersAsync();

        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        Task<CharacterResponse> AddChacterAsync(CreateCharacterRequest character);

        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);

        Task<bool> DeleteCharacterByIdAsync(int id);
    }
}
