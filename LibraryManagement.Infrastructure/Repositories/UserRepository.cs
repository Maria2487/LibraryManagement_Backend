using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await dbSet.FirstAsync(user => user.Email.ToLower() == email.ToLower() && user.IsDeleted == false);
        }
    }
}
