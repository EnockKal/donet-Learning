using TaskManagementAPI.Models.Entities.Enums;

namespace TaskManagementAPI.DTOs.TaskDTOS
{
    public class TaskRequestDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Models.Entities.Enums.TaskStatus Status { get; internal set; }
    }
}
