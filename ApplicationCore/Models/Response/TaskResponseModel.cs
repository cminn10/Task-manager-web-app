using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.Response
{
    public class TaskResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Completed { get; set; }
        public char Priority { get; set; }
        public string Remarks { get; set; }

        public UserResponseModel User { get; set; }
    }
}