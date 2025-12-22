namespace TaskManagement.API.Models.Dto
{
    public class UpdateProjectRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EstimatedTimeInHours { get; set; }
    }
}
