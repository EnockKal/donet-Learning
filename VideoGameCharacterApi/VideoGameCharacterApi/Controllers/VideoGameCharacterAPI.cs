using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models.Service;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterAPI(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CharacterResponse>> GetCharacters()
            => Ok(await service.GetallCharactersAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacterById(int id)
        {
            var charactere = await service.GetCharacterByIdAsync(id);
            if (charactere is null)
                return NotFound("Character with this Id wasn't found");
            return Ok(charactere);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var create = await service.AddChacterAsync(character);
            return CreatedAtAction(
                nameof(GetCharacterById),
                new { id = create.Id },
                create);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            var update = await service.UpdateCharacterAsync(id, character);
            return update ? NoContent() : NotFound("Character with this Id wasn't found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var delete = await service.DeleteCharacterByIdAsync(id);
            return delete ? NoContent() : NotFound("Character with this Id wasn't found.");
        }
    }
}
