using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;

namespace LibraryManagement.Infrastructure.Repositories.Interfaces
{
    public interface ILoanRepository : IBaseEntityRepository<Loan>
    {
        Task<List<Loan>> GetActiveLoans(Guid membershipId);
        Task<int> GetNumberOfReturnedLoans(Guid membershipId);
        Task<List<Loan>> GetPassedDueDate(Guid membershipId);
    }
}
