using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Application.DTOs.User
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? ProfilePicture { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
