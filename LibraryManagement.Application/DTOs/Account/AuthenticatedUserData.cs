﻿namespace LibraryManagement.Application.DTOs.Account
{
    public class AuthenticatedUserData
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
