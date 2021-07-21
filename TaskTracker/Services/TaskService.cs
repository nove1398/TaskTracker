using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Dto;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public interface ITaskService
    {
        Task<Tasks> CreateTask(CreateTaskDto request);

        Task<bool> AssignTask(AssignTaskDto request);

        Task<Tasks> GetTask(int taskId);

        Task<Tasks> ChangeTaskStatus(int taskId, UpdateTaskStatusDto newStatus);

        Task<List<Tasks>> GetAllTasks(int page = 1, int pageSize = 30);

        Task<List<Status>> GetAllStatus();
    }

    public class TaskService : ITaskService
    {
        private readonly TaskTrackerDbContext _dbContext;

        public TaskService(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AssignTask(AssignTaskDto request)
        {
            //User and task must exist before
            if (request.TaskIds.Count > 0)
            {
                var task = _dbContext.Tasks.AsNoTracking().Any(x => request.TaskIds.Contains(x.Id));
                if (!task)
                    return false;
            }
            var employee = _dbContext.Employees.AsNoTracking().Any(x => x.Id == request.EmployeeId);
            if (!employee && request.TaskIds.Count > 0)
                return false;

            //Check if previously assigned
            var employeeAssignments = await _dbContext.AssignedTasks
                .Where(t => t.EmployeeId == request.EmployeeId).ToListAsync();
            _dbContext.AssignedTasks.RemoveRange(employeeAssignments);

            var list = new List<AssignedTasks>();
            foreach (var t in request.TaskIds)
            {
                var newAssignment = new AssignedTasks
                {
                    EmployeeId = request.EmployeeId,
                    TaskId = t
                };
                list.Add(newAssignment);
            }
            _dbContext.AssignedTasks.AddRange(list);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Tasks> ChangeTaskStatus(int taskId, UpdateTaskStatusDto newStatus)
        {
            //Check if task exists
            var exists = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (exists == null)
            {
                return null;
            }

            //Check if status exists
            var statusExists = _dbContext.TaskStatus.Any(t => t.Id == newStatus.NewStatusId);
            if (!statusExists)
                return null;

            exists.StatusId = newStatus.NewStatusId;
            await _dbContext.SaveChangesAsync();

            return await GetTask(exists.Id);
        }

        public async Task<List<Tasks>> GetAllTasks(int page = 1, int pageSize = 30)
        {
            if (!_dbContext.Tasks.Any())
                return new List<Tasks>();

            return await _dbContext.Tasks.AsNoTracking()
                                    .Include(t => t.AssignedTasks)
                                        .ThenInclude(u => u.Employee)
                                    .Include(t => t.Status)
                                    .OrderByDescending(x => x.CreatedAt)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        }

        public async Task<Tasks> CreateTask(CreateTaskDto request)
        {
            var newTask = new Tasks
            {
                DueDate = request.DueDate,
                Description = request.Description,
                StatusId = request.StatusId
            };
            _dbContext.Tasks.Add(newTask);
            await _dbContext.SaveChangesAsync();

            return await GetTask(newTask.Id);
        }

        public async Task<Tasks> GetTask(int taskId)
        => await _dbContext.Tasks.AsNoTracking()
                                .Include(t => t.AssignedTasks)
                                    .ThenInclude(at => at.Employee)
                                .Include(t => t.Status)
                                    .FirstOrDefaultAsync(t => t.Id == taskId);

        public async Task<List<Status>> GetAllStatus()
        {
            return await _dbContext.TaskStatus.AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }
    }
}