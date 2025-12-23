namespace TaskManagement.API.Models.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? EstimatedTimeInHours { get; set; }
    }
}
