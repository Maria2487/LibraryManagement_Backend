
namespace LibraryManagement.Application.DTOs.MembershipType
{
    public class ResponseMembershipTypeDto : MembershipTypeDto
    {
        public int Id { get; set; }
        public string? MembershipName { get; set; }
        public double Price { get; set; }

    }
}
