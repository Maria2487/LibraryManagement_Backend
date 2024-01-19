﻿namespace LibraryManagement.Application.DTOs.User
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
