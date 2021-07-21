using System;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class AssignedTasks
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Tasks Task { get; set; }
        public Employee Employee { get; set; }
    }
}