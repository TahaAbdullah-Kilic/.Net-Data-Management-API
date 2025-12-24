using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public interface IWorkTaskRepository
    {
        Task<List<WorkTask>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100);
        Task<WorkTask?> GetByIdAsync(Guid id);
        Task<WorkTask> CreateAsync(WorkTask workTask);
        Task<WorkTask?> UpdateAsync(Guid id, WorkTask workTask);
        Task<WorkTask?> DeleteAsync(Guid id);
    }
}
