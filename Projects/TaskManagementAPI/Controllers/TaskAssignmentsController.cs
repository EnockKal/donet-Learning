using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs.TaskDTOS;

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


        [HttpPut("{taskId}/unassign")]
        public async Task<IActionResult> UnAssigningTaskToUser(int taskId)
        {
            var existingTask = await context.TaskItems.FindAsync(taskId);
            if (existingTask is null) { return NotFound($"There is no Task with {taskId} as ID"); }

            existingTask.UserId = null;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/api/taskassignments/user/{userId}")]
        public async Task<IActionResult> GetTasksAssignedToUser(int userId)
        {
            var existingUser = await context.Users.FindAsync(userId);
            if (existingUser is null) { return NotFound($"There is no user with {userId} as ID"); }

            var tasks = await context.TaskItems
                .Where(u => u.UserId == userId)
                .Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate
                })
                .ToListAsync();

            return Ok(tasks);
        }
    }
}
