namespace TaskManagement.API.Models.Domain
{
    public class WorkTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid ProjectId { get; set; }
        public Guid PriorityId { get; set; }

        public Project Project { get; set; }
        public Priority Priority { get; set; }
    }
}
