using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(string? filterQuery,bool isAscending, int pageNumber = 1, int pageSize = 100);
        Task<Project?> GetByIdAsync(Guid id);
        Task<Project> CreateAsync(Project project);
        Task<Project?> UpdateAsync(Guid id, Project project);
        Task<Project?> DeleteAsync(Guid id);
    }
}
