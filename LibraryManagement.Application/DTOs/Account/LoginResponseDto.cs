namespace LibraryManagement.Application.DTOs.Account
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
