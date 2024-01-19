using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Domain.Entities.EnumEntities
{
    [Serializable]
    public record Publisher : BaseEnumEntity
    {
        public List<Book>? Books { get; set; }
    }
}
