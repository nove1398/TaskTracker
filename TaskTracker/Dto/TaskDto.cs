using System;
using System.Collections.Generic;

namespace TaskTracker.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}