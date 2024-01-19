using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;

namespace LibraryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IBaseEntityRepository<User>
    {
        public Task<User?> GetByEmail(string email);
    }
}
