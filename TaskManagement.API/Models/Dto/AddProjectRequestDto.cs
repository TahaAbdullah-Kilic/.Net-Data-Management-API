namespace TaskManagement.API.Models.Dto
{
    public class AddProjectRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EstimatedTimeInHours { get; set; }
    }
}
