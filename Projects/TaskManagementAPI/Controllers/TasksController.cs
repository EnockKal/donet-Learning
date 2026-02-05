using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs.TaskDTOS;
using TaskManagementAPI.Models.Entities;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController(AppDbContext context) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var taskToGet = await context.TaskItems
                .Where(t => t.Id == id)
                .Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate,

                })
                .SingleOrDefaultAsync();

            if (taskToGet is null) { return NotFound(); }

            return Ok(taskToGet);
        }


        [HttpPost("/api/Projects/{projectId}/Task")]
        public async Task<IActionResult> CreateTask(int projectId, TaskRequestDTO task)
        {
            var projectExist = await context.Projects.AnyAsync(p => p.Id == projectId);
            if (!projectExist) return NotFound("Project not found");

            var newTask = new TaskItem
            {
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                Status = Models.Entities.Enums.TaskStatus.Todo,
                DueDate = task.DueDate,
                ProjectId = projectId,
            };

            context.TaskItems.Add(newTask);
            await context.SaveChangesAsync();

            var taskToReturn = new TaskResponseDTO
            {
                Id = newTask.Id,
                Title = newTask.Title,
                Description = newTask.Description,
                DueDate = newTask.DueDate,
                Priority = newTask.Priority,
                Status = Models.Entities.Enums.TaskStatus.Todo,
            };

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = taskToReturn.Id },
                taskToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasksToGet = await context.TaskItems
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

            return Ok(tasksToGet);
        }

        [HttpGet("/api/Tasks/project/{projectId}")]
        public async Task<IActionResult> GetAllTasksForProject(int projectId)
        {
            var projectExist = await context.Projects.AnyAsync(p => p.Id == projectId);
            if (!projectExist) return NotFound("Project not found");

            var allTask = await context.TaskItems
                .Where(t => t.ProjectId == projectId)
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

            return Ok(allTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskRequestDTO task)
        {
            var TaskToUpdate = await context.TaskItems.FindAsync(id);
            if (TaskToUpdate is null) { return NotFound($"There is no Task with {id} as ID"); }

            if (string.IsNullOrWhiteSpace(task.Title)) { return BadRequest("No Title was provided"); }
            TaskToUpdate.Title = task.Title;
            TaskToUpdate.Description = task.Description;
            TaskToUpdate.Status = task.Status;
            TaskToUpdate.Priority = task.Priority;
            TaskToUpdate.DueDate = task.DueDate;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var TaskToDelete = await context.TaskItems.FindAsync(id);
            if (TaskToDelete is null) { return NotFound($"There is no Task with {id} as ID"); }

            context.TaskItems.Remove(TaskToDelete);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
