using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models.Dto
{
    public class RegisterRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
