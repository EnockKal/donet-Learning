using TaskManagementAPI.Models.Entities.Enums;

namespace TaskManagementAPI.DTOs.TaskDTOS
{
    public class TaskResponseDTO
    {
        public int Id { get; set; }

        public required string Title { get; set; }
        public string? Description { get; set; }

        public Models.Entities.Enums.TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
