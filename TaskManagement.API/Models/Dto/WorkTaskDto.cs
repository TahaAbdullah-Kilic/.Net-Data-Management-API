using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Models.Dto
{
    public class WorkTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid ProjectId { get; set; }
        public Guid PriorityId { get; set; }

        public ProjectDto Project { get; set; }
        public PriorityDto Priority { get; set; }
    }
}
