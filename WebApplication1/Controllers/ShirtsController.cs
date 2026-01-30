using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters.ActionFilters;
using WebApplication1.Filters.ExceptionFilters;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    [ApiController] // makes it a proper API controller (validation + smarter responses)
    [Route("api/[controller]")] // auto uses controller name
    public class ShirtsController : ControllerBase
    {
        [HttpGet] // maps to GET request
        public IActionResult GetShirt()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilte]
        public IActionResult GetShirtById(int id) // using IActionResult as return type to simplify dev process and good for Unit Testing,...
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateShirtCreateFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilte]
        [Shirt_ValidateShirtUpdateFilter]
        [Shirt_HandleUpdateExeptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilte]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
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

        //[HttpGet("{id}/{color}")]
        //public IActionResult GetShirtByIdAndColor(int id, [FromBody] string color)
        //{
        //    return Ok($"Reading all shirts: {id}");
        //}
    }
}
