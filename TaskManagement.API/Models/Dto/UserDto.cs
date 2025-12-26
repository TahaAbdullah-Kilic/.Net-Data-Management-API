namespace TaskManagement.API.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
