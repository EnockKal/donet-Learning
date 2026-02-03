using TaskManagementAPI.Models.Entities.Enums;

namespace TaskManagementAPI.Models.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public required string Title { get; set; }
        public string? Description { get; set; }

        public TaskStatus Status { get; set; }
        public TaskItemPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
