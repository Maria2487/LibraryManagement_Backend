using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Entities.JoiningEntities;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    public record Membership : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid MemberId { get; set; }
        public virtual User Member { get; set; }
        public List<Loan>? Loans { get; set; }

        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public List<Bookings>? Bookings { get; set; }

    }
}
