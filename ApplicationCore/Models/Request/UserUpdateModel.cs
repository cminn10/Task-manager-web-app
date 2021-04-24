namespace ApplicationCore.Models.Request
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }
    }
}