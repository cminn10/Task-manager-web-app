using System;

namespace ApplicationCore.Entities
{
    public class AppTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public char Priority { get; set; }
        public string Remarks { get; set; }

        public AppUser User { get; set; }
    }
}