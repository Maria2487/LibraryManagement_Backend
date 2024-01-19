using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LoanRepository : BaseEntityRepository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<List<Loan>> GetActiveLoans(Guid membershipId)
        {
            return await dbSet.Where(l => l.MembershipId == membershipId && l.Status == Domain.Enums.LoanStatus.Active).ToListAsync();
        }

        public override async Task<Loan?> GetById(Guid id)
        {
            return await dbSet.Include(l => l.Book).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<int> GetNumberOfReturnedLoans(Guid membershipId)
        {
            return await dbSet.Where(l => l.MembershipId == membershipId && l.Status == Domain.Enums.LoanStatus.Returned).CountAsync();
        }

        public async Task<List<Loan>> GetPassedDueDate(Guid membershipId)
        {
            return await dbSet
                .Include(l => l.Book)
                    .ThenInclude(b => b.Authors)
                 .Include(l => l.Book)
                    .ThenInclude(b => b.Genres)
                 .Include(l => l.Book)
                    .ThenInclude(b => b.Publisher)
                .Where(l => l.MembershipId == membershipId 
                    && l.ReturnDate == null
                    && DateTime.UtcNow > l.DueDate)
                .ToListAsync();
        }
    }
}
