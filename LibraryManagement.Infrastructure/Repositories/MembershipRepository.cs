using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class MembershipRepository : BaseEntityRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<Membership?> GetMembership(Guid memberId)
        {
            return await dbSet.SingleOrDefaultAsync(m => m.MemberId == memberId);
        }

        public override async Task<Membership?> GetById(Guid id)
        {
            return await dbSet.Include(m => m.Loans)
                .Include(m => m.MembershipType)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
