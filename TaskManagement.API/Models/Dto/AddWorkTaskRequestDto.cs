namespace TaskManagement.API.Models.Dto
{
    public class AddWorkTaskRequestDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid ProjectId { get; set; }
        public Guid PriorityId { get; set; }
    }
}
