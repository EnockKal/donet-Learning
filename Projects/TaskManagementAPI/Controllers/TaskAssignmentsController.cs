using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskAssignmentsController(AppDbContext context) : ControllerBase
    {
        [HttpPut("/api/tasks/{taskId}/assign/{userId}")]
        public async Task<IActionResult> AssigningTaskToUser(int taskId, int userId)
        {
            var existingUser = await context.Users.FindAsync(userId);
            if (existingUser is null) { return NotFound($"There is no user with {userId} as ID"); }

            var existingTask = await context.TaskItems.FindAsync(taskId);
            if (existingTask is null) { return NotFound($"There is no Task with {taskId} as ID"); }

            if (existingTask.UserId == userId) { return Conflict("This task is already assiigned to this user"); }

            existingTask.UserId = userId;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
