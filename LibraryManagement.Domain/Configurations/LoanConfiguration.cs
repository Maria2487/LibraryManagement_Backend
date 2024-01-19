using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class LoanConfiguration : BaseEntityConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            base.Configure(builder);

            builder.Property(loan => loan.IssueDate)
                .IsRequired();

            builder.Property(loan => loan.ReturnDate)
                .IsRequired(false);

            builder.Property(loan => loan.DueDate)
                .IsRequired();

            builder.Property(loan => loan.Status)
                .IsRequired();

            builder.HasOne(loan => loan.Book)
                .WithMany(book => book.Loans)
                .HasForeignKey(loan => loan.BookId);

            builder.HasOne(loan => loan.Membership)
                .WithMany(membership => membership.Loans)
                .HasForeignKey(loan => loan.MembershipId);
        }
    }
}
