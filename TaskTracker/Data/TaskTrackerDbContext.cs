using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasKey(x => x.Id);
            builder.Entity<Tasks>().HasKey(x => x.Id);
            builder.Entity<Status>().HasKey(x => x.Id);
            builder.Entity<AssignedTasks>().HasKey(x => new { x.EmployeeId, x.TaskId });

            builder.Entity<Employee>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Tasks>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<AssignedTasks>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<AssignedTasks>()
                .HasOne(x => x.Employee)
                .WithMany(t => t.AssignedTasks)
                .HasForeignKey(t => t.EmployeeId);

            builder.Entity<Tasks>()
                .HasOne(x => x.Status)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.StatusId);

            builder.Entity<AssignedTasks>()
                   .HasOne(x => x.Task)
                   .WithMany(t => t.AssignedTasks)
                   .HasForeignKey(t => t.TaskId);

            //Seeding
            var statusList = new List<Status>
            {
                new Status{ Id = 1, Name = "not yet started"},
                new Status{ Id = 2, Name = "in progress"},
                new Status{ Id = 3, Name = "completed"},
                new Status{ Id = 4, Name = "past due"},
            };
            builder.Entity<Status>().HasData(statusList);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AssignedTasks> AssignedTasks { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status> TaskStatus { get; set; }
    }
}