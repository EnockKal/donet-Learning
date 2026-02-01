using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Models.Service;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterAPI(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Character>> GetCharacters()
            => Ok(await service.GetallCharactersAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var charactere = await service.GetCharacterByIdAsync(id);
            if (charactere is null)
                return NotFound("Character with this Id wasn't found");
            return Ok(charactere);
        }
    }
}
