using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.DTOs.Loan;

namespace LibraryManagement.Application.DTOs.Status
{
    public class ResponseStatusDto
    {
        public int Id { get; set; }
        public List<ResponseLoanDto>? Loans { get; set; }
        public List<ResponseBookDto>? Books { get; set; }
    }
}
