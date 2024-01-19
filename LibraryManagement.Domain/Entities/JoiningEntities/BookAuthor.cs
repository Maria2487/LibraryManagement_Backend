using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Domain.Entities.JoiningEntities
{
    [Serializable]
    public record BookAuthor
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
