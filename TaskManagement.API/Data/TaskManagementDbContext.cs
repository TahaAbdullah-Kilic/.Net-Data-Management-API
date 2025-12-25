using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> dbContextOptions) : base(dbContextOptions)
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
                    Title = "Low"
                },
                new Priority()
                {
                    Id = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    Title = "Medium"
                },
                new Priority()
                {
                    Id = Guid.Parse("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                    Title = "High"
                }
            };  

            var Projects = new List<Project>()
            {
                new Project()
                {
                    Id = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    Title = "Project Alpha",
                    Description = "This is the first project.",                    
                },
                new Project()
                {
                    Id = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    Title = "Project Beta",
                    Description = "This is the second project.",
                },
                new Project()
                {
                    Id = Guid.Parse("8f3a2c91-6b7e-4f5c-9a12-1d3e5b7c9a21"),
                    Title = "E-Commerce Management System",
                    Description = "An e-commerce infrastructure covering product, order, and inventory management."
                },
                new Project()
                {
                    Id = Guid.Parse("c1e47b62-2d94-4a88-bf73-9e6a41d0f5bc"),
                    Title = "Corporate Website Redesign",
                    Description = "Redevelopment of the company’s existing website with a modern UI and performance-focused approach."
                },
                new Project()
                {
                    Id = Guid.Parse("b1a7f3e2-4c8a-4e0a-9d3f-1b2c3d4e5f60"),
                    Title = "Human Resources Management System",
                    Description = "Digital management of employee, leave, performance, and payroll processes."
                },
                new Project()
                {
                    Id = Guid.Parse("c2d4e6f8-1a3b-4c5d-9e7f-8a9b0c1d2e34"),
                    Title = "Inventory and Warehouse Tracking Application",
                    Description = "Real-time monitoring of warehouse movements and inventory levels."
                },
                new Project()
                {
                    Id = Guid.Parse("e9f1a2b3-4c5d-6e7f-8a9b-0c1d2e3f4a56"),
                    Title = "Customer Support and Ticketing System",
                    Description = "Tracking and reporting customer requests using a ticket-based workflow."
                },
                new Project()
                {
                    Id = Guid.Parse("f0123456-789a-4bcd-8e9f-0123456789ab"),
                    Title = "Finance and Invoice Tracking System",
                    Description = "Centralized management of income, expenses, invoices, and payment processes."
                }
            };

            var Tasks = new List<WorkTask>()
            {
                new WorkTask()
                {
                    Id = Guid.Parse("d2f1c4e8-3b6a-4f5e-9f3e-1c2b3a4d5e6f"),
                    Title = "Design Database Schema",
                    Description = "Create the initial database schema for the project.",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask()
                {
                    Id = Guid.Parse("e3f2d5c6-4a7b-4c8d-9e0f-2a3b4c5d6e7f"),
                    Title = "Implement Authentication",
                    Description = "Develop the authentication module for user login and registration.",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("4a2f1e9e-edaa-42bc-9387-649afa9cc936"),
                    Title = "Alpha Task 1",
                    Description = "Description for Alpha Task 1",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("a857d5c3-7608-4100-9f32-b1e0a099fba1"),
                    Title = "Alpha Task 2",
                    Description = "Description for Alpha Task 2",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("4a61d1e9-226e-4e78-8e03-17ac17b8e74a"),
                    Title = "Alpha Task 3",
                    Description = "Description for Alpha Task 3",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("16d791fc-688d-4568-a107-27671392d18d"),
                    Title = "Alpha Task 4",
                    Description = "Description for Alpha Task 4",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("99e2e800-7ee7-4fdc-a8b5-ed6f47f95ada"),
                    Title = "Alpha Task 5",
                    Description = "Description for Alpha Task 5",
                    ProjectId = Guid.Parse("073859b5-ae0c-4473-a156-435934ab5467"),
                    PriorityId = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    EstimatedTimeInHours = 100
                },

                new WorkTask
                {
                    Id = Guid.Parse("1e7a6ab0-828b-473f-bb29-a2c80f510ece"),
                    Title = "Beta Task 1",
                    Description = "Description for Beta Task 1",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("ace396b7-69bd-450b-97cd-da1aa5450914"),
                    Title = "Beta Task 2",
                    Description = "Description for Beta Task 2",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("f8d002be-2f6a-4b55-a209-23e076ddfc8f"),
                    Title = "Beta Task 3",
                    Description = "Description for Beta Task 3",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("a3f9b849-d41c-49e9-bbc1-8f23df2e69dd"),
                    Title = "Beta Task 4",
                    Description = "Description for Beta Task 4",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                    EstimatedTimeInHours = 100
                },
                new WorkTask
                {
                    Id = Guid.Parse("74e7c49d-0b01-4121-a45a-4555d0d2d6c3"),
                    Title = "Beta Task 5",
                    Description = "Description for Beta Task 5",
                    ProjectId = Guid.Parse("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                    PriorityId = Guid.Parse("6878803a-19d8-45ac-b84e-5b0f68989132"),
                    EstimatedTimeInHours = 100
                }
            };
            
            modelBuilder.Entity<Priority>().HasData(Priorities);
            modelBuilder.Entity<Project>().HasData(Projects);
            modelBuilder.Entity<WorkTask>().HasData(Tasks);
        }
    }
}
