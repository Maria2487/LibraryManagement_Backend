using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.JoiningEntities;

namespace LibraryManagement.Domain.Entities.EnumEntities
{
    public record Genre : BaseEnumEntity
    {
        public List<BookGenre>? Books { get; set; }
    }
}
