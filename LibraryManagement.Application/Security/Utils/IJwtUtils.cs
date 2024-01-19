using LibraryManagement.Application.DTOs.Account;
using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Application.Security.Utils
{
    public interface IJwtUtils
    {
        string GenerateToken(User user);
        AuthenticatedUserData? ValidateToken(string token);
    }
}
