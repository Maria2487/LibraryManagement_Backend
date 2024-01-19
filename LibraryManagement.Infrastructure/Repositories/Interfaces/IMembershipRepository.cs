using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;

namespace LibraryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IMembershipRepository : IBaseEntityRepository<Membership>
    {
        Task<Membership?> GetMembership(Guid memberId);
    }
}
