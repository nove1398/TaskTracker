using System;
using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<AssignedTasks> AssignedTasks { get; set; }
    }
}