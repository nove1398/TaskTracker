using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Dto;
using TaskTracker.Models;

namespace TaskTracker.Mappers
{
    public static class DtoMapping
    {
        public static StatusDto ToDto(this Status source)
        {
            return new StatusDto
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public static List<StatusDto> ToDto(this List<Status> source)
        {
            return source.Select(x => x.ToDto()).ToList();
        }

        public static EmployeeDto ToDto(this Employee source)
        {
            return new EmployeeDto
            {
                CreatedAt = source.CreatedAt,
                Department = source.Department,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Id = source.Id,
                UpdatedAt = source.UpdatedAt
            };
        }

        public static TaskDto ToDto(this Tasks source)
        {
            return new TaskDto
            {
                CreatedAt = source.CreatedAt,
                Description = source.Description,
                DueDate = source.DueDate,
                Employees = source.AssignedTasks != null ?
                            source.AssignedTasks.Select(x => x.Employee.ToDto()).ToList() : default,
                Id = source.Id,
                Status = source.Status.Name
            };
        }

        public static List<TaskDto> ToDto(this List<Tasks> source)
        {
            return source.Select(x => x.ToDto()).ToList();
        }

        public static List<EmployeeDto> ToDto(this List<Employee> source)
        {
            return source.Select(x => x.ToDto()).ToList();
        }
    }
}