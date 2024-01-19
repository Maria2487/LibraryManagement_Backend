namespace LibraryManagement.Application.DTOs.Loan
{
    public class ResponseLoanDto : LoanDto
    {
        public Guid Id { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
