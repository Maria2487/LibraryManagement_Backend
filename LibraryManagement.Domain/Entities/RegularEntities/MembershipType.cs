using LibraryManagement.Domain.Entities.Base;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    public record MembershipType : BaseEnumEntity
    {
        public int NumberOfLoansAllowed { get; set; }
        public int NumberOfLoansNeeded { get; set; }
        public string? Badge { get; set; }
        public double Price { get; set; }

        public List<Membership> Membership { get; set; }
    }
}
