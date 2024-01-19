using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class AuthorRepository : BaseEntityRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
