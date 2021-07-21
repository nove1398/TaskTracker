using System;
using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<AssignedTasks> AssignedTasks { get; set; }
    }
}