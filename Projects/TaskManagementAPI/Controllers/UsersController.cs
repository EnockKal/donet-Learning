using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs.UserDTO;
using TaskManagementAPI.Models.Entities;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController(AppDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
            };

            if (string.IsNullOrWhiteSpace(newUser.FullName)) { return BadRequest("No User's Name was provided"); }

            if (string.IsNullOrWhiteSpace(newUser.Email)) { return BadRequest("No User's email was provided"); }


            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            var userToReturn = new UserResponseDTO
            {
                Id = newUser.Id,
                FullName = newUser.FullName,
                Email = newUser.Email,

            };

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = userToReturn.Id },
                userToReturn);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userToGet = await context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserResponseDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                })
                .SingleOrDefaultAsync();

            if (userToGet == null)
                return NotFound($"There is no User with {id} as ID");

            return Ok(userToGet);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await context.Users
                .Select(u => new UserResponseDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                }).ToListAsync();

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequestDTO user)
        {
            var existingUser = await context.Users.FindAsync(id);

            if (existingUser == null) return NotFound($"There is no User with {id} as ID");

            if (string.IsNullOrWhiteSpace(user.FullName)) { return BadRequest("No User's Name was provided"); }

            if (string.IsNullOrWhiteSpace(user.Email)) { return BadRequest("No User's email was provided"); }

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
