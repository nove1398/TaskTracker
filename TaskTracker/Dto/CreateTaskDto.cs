using System;

namespace TaskTracker.Dto
{
    public class CreateTaskDto
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
    }
}