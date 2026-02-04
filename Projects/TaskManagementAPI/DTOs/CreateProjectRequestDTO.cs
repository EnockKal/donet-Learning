namespace TaskManagementAPI.DTOs
{
    public class CreateProjectRequestDTO
    {
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
    }
}
