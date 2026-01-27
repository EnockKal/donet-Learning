using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController] // makes it a proper API controller (validation + smarter responses)
    [Route("api/[controller]")] // auto uses controller name
    public class ShirtsController : ControllerBase
    {
        [HttpGet] // maps to GET request
        public string GetShirt()
        {
            return "Reading all shirts";
        }

        [HttpGet("{id}")]
        public string GetShirtById(int id)
        {
            return $"Reading all shirts: {id}";
        }

        //[HttpPost]
        //public string CreateShirt()
        //{
        //    return $"Creating shirt";
        //}

        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }

        [HttpDelete("{id}")]
        public string DeletetingShirt(int id)
        {
            return $"Updating shirt: {id}";
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
        public string GetShirtByIdAndColor(int id, [FromBody] string color)
        {
            return $"Reading all shirts: {id}";
        }

        [HttpPost]
        public string CreateShirtFromBody([FromBody] Shirt shirt)
        {
            return $"Creating shirt";
        }
    }
}
