using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Application.DTOs.Book
{
    public class BookDto
    {
        public string Title { get; set; }
        public int Edition { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
        public BookStatus Status { get; set; }
        public int PublisherId { get; set; }
        public List<int>? GenreIDs { get; set; }
        public List<Guid>? AuthorIds { get; set; }
    }
}
