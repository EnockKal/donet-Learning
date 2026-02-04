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
        public async Task<IActionResult> CreateProject(CreateProjectRequestDTO project)
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
    }
}
