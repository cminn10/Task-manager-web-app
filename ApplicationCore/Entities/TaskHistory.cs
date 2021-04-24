using System;

namespace ApplicationCore.Entities
{
    public class TaskHistory
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Completed { get; set; }
        public string Remarks { get; set; }
        
        //navs
        public Task Task { get; set; }
        public AppUser User { get; set; }
    }
}