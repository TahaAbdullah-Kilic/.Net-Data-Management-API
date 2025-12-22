using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public interface IWorkTaskRepository
    {
        Task<List<WorkTask>> GetAllAsync();
        Task<WorkTask?> GetByIdAsync(Guid id);
        Task<WorkTask> CreateAsync(WorkTask workTask);
        Task<WorkTask?> UpdateAsync(Guid id, WorkTask workTask);
        Task<WorkTask?> DeleteAsync(Guid id);
    }
}
