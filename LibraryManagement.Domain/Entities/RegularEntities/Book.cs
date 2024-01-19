using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Domain.Entities.JoiningEntities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    [Serializable]
    public record Book : BaseEntity
    {
        public string Title { get; set; }
        public int Edition { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string? Description { get; set; }
        public string CoverPhoto { get; set; }
        public BookStatus Status { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Guid LocationId { get; set; }
        public List<Loan>? Loans { get; set; }
        public List<BookGenre>? Genres { get; set; }
        public List<BookAuthor>? Authors { get; set; }
        //public List<UserFavorite>? Favorites { get; set;}

        public List<Bookings>? Bookings { get; set; }
    }
}
