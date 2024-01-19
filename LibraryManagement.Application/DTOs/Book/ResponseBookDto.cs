using LibraryManagement.Application.DTOs.Author;
using LibraryManagement.Application.DTOs.Genre;
using LibraryManagement.Application.DTOs.Publisher;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Application.DTOs.Book
{
    public class ResponseBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Edition { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
        public BookStatus Status { get; set; }
         
        public BookPublisherDto Publisher { get; set; }
        public List<GenreDto>? Genres { get; set; }
        public List<BookAuthorDto>? Authors { get; set; }

    }
}
