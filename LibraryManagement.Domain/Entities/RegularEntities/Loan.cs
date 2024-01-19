using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities.RegularEntities
{
    [Serializable]
    public record Loan : BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public virtual LoanStatus Status { get; set; }

        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public Guid MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
