using LibraryManagement.Application.DTOs.Book;

namespace LibraryManagement.Application.DTOs.Loan
{
    public class ResponseBookLoanDto : ResponseLoanDto
    {
        public ResponseBookDto Book { get; set; }
    }
}
