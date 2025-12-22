using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Data
{
    public class TaskManagementDbContext :DbContext
    {
        public TaskManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<WorkTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Priorities = new List<Priority>()
            {
                new Priority()
                {
                    Id = Guid.Parse("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                    Title = "Easy"
                },
                new Priority()
                {
                    Id = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    Title = "Medium"
                },
                new Priority()
                {
                    Id = Guid.Parse("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                    Title = "Hard"
                }
            };

            modelBuilder.Entity<Priority>().HasData(Priorities);

            var Projects = new List<Project>()
            {
                new Project()
                {
                    Id = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    Title = "Project Alpha",
                    Description = "This is the first project.",
                    EstimatedTimeInHours = 100
                },
                new Project()
                {
                    Id = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    Title = "Project Beta",
                    Description = "This is the second project.",
                    EstimatedTimeInHours = 150
                }
            }; 
            
            modelBuilder.Entity<Project>().HasData(Projects);
        }
    }
}
