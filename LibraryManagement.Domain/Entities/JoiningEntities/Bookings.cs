using LibraryManagement.Domain.Entities.RegularEntities;

namespace LibraryManagement.Domain.Entities.JoiningEntities
{
    [Serializable]
    public record Bookings
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
