using LibraryManagement.Application.DTOs.Membership;

namespace LibraryManagement.Application.DTOs.User
{
    public class ResponseUserDto : UserDto
    {
        public Guid Id { get; set; }
        public ResponseMembershipDto Membership { get; set; }

    }
}
