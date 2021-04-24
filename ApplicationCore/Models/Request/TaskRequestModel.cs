using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Request
{
    public class TaskRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(50)] public string Title { get; set; }
        [StringLength(500)] public string Description { get; set; }
        [DataType(DataType.Date)] public DateTime DueDate { get; set; }
        public char Priority { get; set; }
        [StringLength(500)] public string Remarks { get; set; }
    }
}