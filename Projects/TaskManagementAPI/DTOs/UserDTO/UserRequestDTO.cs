namespace TaskManagementAPI.DTOs.UserDTO
{
    public class UserRequestDTO
    {
        public string? FullName { get; set; }
        public required string Email { get; set; }
    }
}
