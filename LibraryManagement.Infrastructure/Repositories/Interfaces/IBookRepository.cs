using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;

namespace LibraryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IBookRepository : IBaseEntityRepository<Book>
    {
        Task<List<Book>> GetFiltered(BookFilter filter);
    }
}
