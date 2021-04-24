using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }

        public List<TaskResponseModel> Tasks { get; set; }
    }
}