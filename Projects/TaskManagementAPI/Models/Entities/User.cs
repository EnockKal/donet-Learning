using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public required string Email { get; set; }
    }
}
