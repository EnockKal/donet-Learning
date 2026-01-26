using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        public string GetShirt()
        {
            return "Reading all shirts";
        }

        public string GetShirtById(int id)
        {
            return $"Reading all shirts: {id}";
        }

        public string CreateShirt()
        {
            return $"Creating shirt";
        }

        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }

        public string DeletetingShirt(int id)
        {
            return $"Updating shirt: {id}";
        }
    }
}
