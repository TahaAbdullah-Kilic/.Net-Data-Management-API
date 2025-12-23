using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models.Dto
{
    public class UpdateWorkTaskRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title has to be a minimum of 3 characters")]
        [MaxLength(100, ErrorMessage = "Title can be a maximum of 100 characters")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Description can be a maximum of 1000 characters")]
        public string? Description { get; set; }

        
        [Required]
        public Guid ProjectId { get; set; }
        
        [Required]
        public Guid PriorityId { get; set; }
    }
}
