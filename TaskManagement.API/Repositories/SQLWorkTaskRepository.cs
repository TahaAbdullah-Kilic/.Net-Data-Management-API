using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public class SQLWorkTaskRepository : IWorkTaskRepository
    {
        readonly TaskManagementDbContext DbContext;

        public SQLWorkTaskRepository(TaskManagementDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<List<WorkTask>> GetAllAsync()
        {
            return await DbContext.Tasks.Include(t => t.Project).Include(t => t.Priority).ToListAsync();
        }

        public async Task<WorkTask?> GetByIdAsync(Guid id)
        {
            return await DbContext.Tasks.Include(t => t.Project).Include(t => t.Priority).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkTask> CreateAsync(WorkTask workTask)
        {
            await DbContext.Tasks.AddAsync(workTask);
            await DbContext.SaveChangesAsync();
            
            return workTask;
        }

        public async Task<WorkTask?> UpdateAsync(Guid id, WorkTask workTask)
        {
            var task = await DbContext.Tasks.Include(t => t.Project).Include(t => t.Priority).FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return null;
            }

            task.Title = workTask.Title;
            task.Description = workTask.Description;
            task.ProjectId = workTask.ProjectId;
            task.PriorityId = workTask.PriorityId;
            
            await DbContext.SaveChangesAsync();
            
            return task;
        }

        public async Task<WorkTask?> DeleteAsync(Guid id)
        {
            var task = await DbContext.Tasks.Include(t => t.Project).Include(t => t.Priority).FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return null;
            }

            DbContext.Tasks.Remove(task);
            await DbContext.SaveChangesAsync();
            
            return task;
        }
    }
}
