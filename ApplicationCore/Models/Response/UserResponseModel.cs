using System.Collections.Generic;
using System.ComponentModel;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }

        public IEnumerable<TaskResponseModel> Tasks { get; set; }
        public IEnumerable<TaskResponseModel> TasksHistories { get; set; }
    }
}