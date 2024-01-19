using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.JoiningEntities;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    public record Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
        public string? Photo { get; set; }

        public List<BookAuthor>? Books { get; set; }
    }
}
