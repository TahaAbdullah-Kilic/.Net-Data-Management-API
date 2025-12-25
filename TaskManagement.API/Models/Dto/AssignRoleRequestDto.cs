using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models.Dto
{
    public class AssignRoleRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
