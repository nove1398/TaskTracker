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
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(CreateEmployeeDto request);

        Task<Employee> GetEmployee(int id);

        Task<List<Employee>> GetEmployees(int page = 1, int pageSize = 30);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly TaskTrackerDbContext _dbContext;

        public EmployeeService(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> CreateEmployee(CreateEmployeeDto request)
        {
            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
            {
                return null;
            }

            //Setup new employee
            var newEmployee = new Employee
            {
                Department = request.Department,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UpdatedAt = null
            };

            _dbContext.Employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();

            return newEmployee;
        }

        public async Task<Employee> GetEmployee(int id)
        => await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<List<Employee>> GetEmployees(int page = 1, int pageSize = 30)
        {
            if (!_dbContext.Employees.Any())
                return new List<Employee>();

            return await _dbContext.Employees.AsNoTracking()
                      .Include(e => e.AssignedTasks)
                          .ThenInclude(at => at.Task)
                          .OrderBy(x => x.Id)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize)
                      .ToListAsync();
        }
    }
}