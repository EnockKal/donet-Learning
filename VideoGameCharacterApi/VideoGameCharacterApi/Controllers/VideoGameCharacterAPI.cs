using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterAPI : ControllerBase
    {
        // Temporary Data to work with
        static List<Character> character = new List<Character>
        {
            new Models.Character { Id = 1, Name = "Mario", Game = "Super Mario Bros", Role = "Hero"},
            new Models.Character { Id = 2, Name = "Link", Game = "Super Mario Bros", Role = "Hero"},
            new Models.Character { Id = 3, Name = "Boweser", Game = "Super Mario Bros", Role = "Hero"}
        };

        [HttpGet]
        public async Task<ActionResult<Character>> GetCharacters()
        {
            return Ok(character);
        }
    }
}
