using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class MembershipTypeRepository : BaseEnumRepository<MembershipType>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Task<List<MembershipType>> GetAllByDeletedStatus(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<MembershipType?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
