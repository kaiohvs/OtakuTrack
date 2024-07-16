using OtakuTrack.Domain.Entities;

namespace OtakuTrack.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }         
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    public class CreateUserDTO
    {     
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    public class UpdateUserDTO
    {     
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
