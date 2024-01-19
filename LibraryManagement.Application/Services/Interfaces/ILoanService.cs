using LibraryManagement.Application.DTOs.Loan;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface ILoanService
    {
        Task<ResponseLoanDto> Create(LoanDto loanDto);
        Task<ResponseLoanDto> GetById(Guid id);
        Task<List<ResponseLoanDto>> GetAll();
        Task<ResponseLoanDto> Update(Guid id, LoanDto loanDto);
        Task Delete(Guid id);
        Task<ResponseLoanDto> ReturnBook(Guid id);
        Task<List<ResponseLoanDto>> GetActiveLoans(Guid membershipId);
        Task<List<ResponseBookLoanDto>> GetPassedDueDate(Guid membershipId);
    }
}
