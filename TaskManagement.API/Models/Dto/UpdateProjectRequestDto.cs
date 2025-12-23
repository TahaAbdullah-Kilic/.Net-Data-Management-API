using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models.Dto
{
    public class UpdateProjectRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title has to be a minimum of 3 characters")]
        [MaxLength(100, ErrorMessage = "Title can be a maximum of 100 characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Description has to be a minimum of 5 characters")]
        [MaxLength(1000, ErrorMessage = "Description can be a maximum of 1000 characters")]
        public string Description { get; set; }

        [Range(0, 1000, ErrorMessage = "Estimated Hours can be a maximum of 1000 hours")]
        public int? EstimatedTimeInHours { get; set; }
    }
}
