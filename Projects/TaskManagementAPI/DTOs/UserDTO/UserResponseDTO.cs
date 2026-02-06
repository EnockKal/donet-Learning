namespace TaskManagementAPI.DTOs.UserDTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public required string Email { get; set; }
    }
}
