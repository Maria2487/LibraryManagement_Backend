using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class GenreRepository : BaseEnumRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
