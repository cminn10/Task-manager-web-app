using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public byte[] PasswordHash { get; set; }
        // public byte[] PasswordSalt { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }

        public ICollection<AppTask> Tasks { get; set; }
        public ICollection<TaskHistory> TasksHistories { get; set; }
    }
}