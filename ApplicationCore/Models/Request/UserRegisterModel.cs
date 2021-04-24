using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Request
{
    public class UserRegisterModel
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Fullname { get; set; }
        public string Mobileno { get; set; }
    }
}