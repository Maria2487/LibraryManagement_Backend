using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.JoiningEntities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    public record User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public string? MemberPhoto { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid? MembershipId { get; set; }
        public virtual Membership? Membership { get; set; }
        //public List<UserFavorite>? Favorites { get; set; }
    }
}
