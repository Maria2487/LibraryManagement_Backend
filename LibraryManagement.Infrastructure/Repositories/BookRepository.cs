using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : BaseEntityRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async override Task<Book?> GetById(Guid id)
        {
            return await dbSet.Include(b => b.Genres).ThenInclude(g => g.Genre)
            .Include(b => b.Authors).ThenInclude(a => a.Author)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetFiltered(BookFilter filter)
        {
            var query = dbSet.AsNoTracking()
                .Include(b => b.Genres!).ThenInclude(g => g.Genre)
                .Include(b => b.Authors).ThenInclude(a => a.Author)
                .Include(b => b.Publisher)
                .AsQueryable();

            query = filter != null ? query.Where(filter.GetQuery()) : query;

            var books = await query.ToListAsync();

            books = filter!.FilterByGenres(books);
            books = filter!.FilterByAuthors(books);

            return books;
        }
    }
}
