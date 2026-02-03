namespace TaskManagementAPI.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
