using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models.Entities;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectsController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await context.Projects
                .Select(p => new ProjectResponseDTO
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt
                }).ToListAsync()
            );
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var projectToGet = await context.Projects
                .Where(p => p.Id == id)
                .Select(p => new ProjectResponseDTO
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt
                })
                .SingleOrDefaultAsync(p => p.Id == id);

            if (projectToGet == null)
                return NotFound();

            return Ok(projectToGet);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectRequestDTO project)
        {
            var newProject = new Project
            {
                ProjectName = project.ProjectName,
                Description = project.Description
            };

            context.Projects.Add(newProject);
            await context.SaveChangesAsync();

            var projectToReturn = new Project
            {
                Id = newProject.Id,
                ProjectName = newProject.ProjectName,
                Description = newProject.Description
            };

            return CreatedAtAction(
                nameof(GetProjectById),
                new { id = projectToReturn.Id },
                projectToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(ProjectRequestDTO project, int id)
        {
            var existingProject = await context.Projects.FindAsync(id);

            if (existingProject is null) return NotFound("There is no project with the given ID");

            if (string.IsNullOrWhiteSpace(project.ProjectName)) return BadRequest("No project Name was provided");
            existingProject.ProjectName = project.ProjectName;
            existingProject.Description = project.Description;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var existingProject = await context.Projects.FindAsync(id);
            if (existingProject is null) return NotFound("There is no project with the given ID");

            var existingTask = await context.TaskItems.AnyAsync(t => t.ProjectId == id);
            if (existingTask)
            {
                return Conflict("Cannot delete project because it has associated tasks.");
            }

            context.Projects.Remove(existingProject);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
