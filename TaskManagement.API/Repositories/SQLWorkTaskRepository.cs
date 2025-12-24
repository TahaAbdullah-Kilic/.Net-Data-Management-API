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

        public async Task<List<WorkTask>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
            var tasks = DbContext.Tasks.Include(t => t.Project).Include(t => t.Priority).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    tasks = tasks.Where(t => t.Title.Contains(filterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    tasks = isAscending
                        ? tasks.OrderBy(t => t.Title)
                        : tasks.OrderByDescending(t => t.Title);
                }
                if (sortBy.Equals("Time", StringComparison.OrdinalIgnoreCase))
                {
                    tasks = isAscending
                        ? tasks.OrderBy(t => t.EstimatedTimeInHours)
                        : tasks.OrderByDescending(t => t.EstimatedTimeInHours);
                }
            }

            pageNumber = pageNumber < 1
                ? 1
                : pageNumber;
            pageSize = pageSize < 1
                ? 10
                : pageSize;

            tasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await tasks.ToListAsync();
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
            task.EstimatedTimeInHours = workTask.EstimatedTimeInHours;
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
