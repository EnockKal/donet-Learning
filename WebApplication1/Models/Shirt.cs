using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Validations;

namespace WebApplication1.Models
{
    // using [Required] to validate the data, or it return an error msg
    public class Shirt
    {
        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }

        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }
    }
}
