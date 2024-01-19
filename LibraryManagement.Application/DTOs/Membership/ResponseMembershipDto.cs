using LibraryManagement.Application.DTOs.Loan;

namespace LibraryManagement.Application.DTOs.Membership
{
    public class ResponseMembershipDto : MembershipDto
    {
        public Guid Id { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ResponseLoanDto>? Loans { get; set; }

    }
}
