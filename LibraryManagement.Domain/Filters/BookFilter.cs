using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Utils;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManagement.Domain.Filters
{
    public class BookFilter
    {
        public List<string>? Genres { get; set; } = null;
        public List<string>? Authors { get; set; } = null;
        public string? Publisher { get; set; } = null;

        public Expression<Func<Book, bool>> GetQuery()
        {
            Expression<Func<Book, bool>> query = book => true;

            if (Publisher is not null)
            {
                query = query.And(book => book.Publisher.Name.ToLower().Contains(Publisher.ToLower()));
            }

            return query;
        }

        public List<Book> FilterByGenres(List<Book> books)
        {
            if (Genres is null)
            {
                return books;
            }

            return books.Where(book => Genres.All(g => book.Genres!.Select(bg => bg.Genre.Name).Contains(g))).ToList();
        }

        public List<Book> FilterByAuthors(List<Book> books)
        {
            if (Authors is null)
            {
                return books;
            }

            return books.Where(book => 
                Authors.All(author =>
                    book.Authors!.Select(ba => $"{ba.Author.LastName} {ba.Author.FirstName}").Any(a => a.Contains(author)))).ToList();
        }
    }
}
