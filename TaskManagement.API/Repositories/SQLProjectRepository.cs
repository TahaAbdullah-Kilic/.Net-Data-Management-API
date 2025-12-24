using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public class SQLProjectRepository : IProjectRepository
    {
        readonly TaskManagementDbContext DbContext;

        public SQLProjectRepository(TaskManagementDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<List<Project>> GetAllAsync(string? filterQuery, bool isAscending, int pageNumber = 1, int pageSize = 100)
        {
            var projects = DbContext.Projects.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(filterQuery))
            {
                projects = projects.Where(p => p.Title.Contains(filterQuery));
            }

            projects = isAscending 
                ? projects.OrderBy(p => p.Title) 
                : projects.OrderByDescending(p => p.Title);

            pageNumber = pageNumber < 1 
                ? 1 
                : pageNumber;
            pageSize = pageSize < 1 
                ? 10 
                : pageSize;

            projects = projects.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await DbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await DbContext.Projects.AddAsync(project);
            await DbContext.SaveChangesAsync();
            
            return project;
        }

        public async Task<Project?> UpdateAsync(Guid id, Project project)
        {
            var existingProject = await DbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProject == null)
            {
                return null;
            }

            existingProject.Title = project.Title;
            existingProject.Description = project.Description;

            await DbContext.SaveChangesAsync();
            
            return existingProject;
        }

        public async Task<Project?> DeleteAsync(Guid id)
        {
            var project = await DbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project == null)
            {
                return null;
            }

            DbContext.Projects.Remove(project);
            await DbContext.SaveChangesAsync();
            
            return project;
        }

        

        

        
    }
}
