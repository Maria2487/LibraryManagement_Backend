using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Domain.Entities.JoiningEntities
{
    [Serializable]
    public record BookGenre
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
