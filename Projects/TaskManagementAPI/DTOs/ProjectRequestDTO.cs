namespace TaskManagementAPI.DTOs
{
    public class ProjectRequestDTO
    {
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
    }
}
