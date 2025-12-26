using TaskManagement.API.Models.Dto;

namespace TaskManagement.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllAsync(bool isAscending, int pageNumber = 1, int pageSize = 100);
        Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> DeleteAsync(string id);
        Task<UserDto> UpdateRolesAsync(string id, string[] roles);
    }
}
