namespace TaskManagement.API.Models.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EstimatedTimeInHours { get; set; }

    }
}
