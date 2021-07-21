using System.Collections.Generic;

namespace TaskTracker.Dto
{
    public class AssignTaskDto
    {
        public List<int> TaskIds { get; set; } = new();
        public int EmployeeId { get; set; }
    }
}