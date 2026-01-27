using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController] // makes it a proper API controller (validation + smarter responses)
    [Route("api/[controller]")] // auto uses controller name
    public class ShirtsController : ControllerBase
    {
        private List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My Band", Color = "Blue", Gender = "Male", Price = 30, Size = 10 },
            new Shirt {ShirtId = 2, Brand = "My Band", Color = "Black", Gender = "Male", Price = 35, Size = 12 },
            new Shirt {ShirtId = 3, Brand = "Your Band", Color = "Pink", Gender = "woMale", Price = 28, Size = 8 },
            new Shirt {ShirtId = 4, Brand = "Your Band", Color = "Yellow", Gender = "woMale", Price = 30, Size = 9 }
        };

        [HttpGet] // maps to GET request
        public IActionResult GetShirt()
        {
            return Ok("Reading all shirts");
        }

        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id) // using IActionResult as return type to simplify dev process and good for Unit Testing,...
        {
            if (id <= 0)
                return BadRequest();

            var shirt = shirts.First(x => x.ShirtId == id);
            if (shirt == null)
                return NotFound();

            return Ok(shirt);
        }

        //[HttpPost]
        //public string CreateShirt()
        //{
        //    return $"Creating shirt";
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletetingShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }

        // Modeling Binding:
        /* specifying where to get data from
         * - [FromRoute]
         * - [FromForm]
         * -[FromBody]
         * -[FromHeader(Name = "color")] 
         * -[FromQuery]
         * - ...
         */

        [HttpGet("{id}/{color}")]
        public IActionResult GetShirtByIdAndColor(int id, [FromBody] string color)
        {
            return Ok($"Reading all shirts: {id}");
        }

        [HttpPost]
        public IActionResult CreateShirtFromBody([FromBody] Shirt shirt)
        {
            return Ok($"Creating shirt");
        }
    }
}
