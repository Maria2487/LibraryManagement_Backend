namespace LibraryManagement.Application.DTOs.Loan
{
    public class LoanDto
    {
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid BookId { get; set; }
        public Guid MembershipId { get; set; }
    }
}
