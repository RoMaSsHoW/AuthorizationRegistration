namespace BLL.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsBlocked { get; set; }
    }
}
