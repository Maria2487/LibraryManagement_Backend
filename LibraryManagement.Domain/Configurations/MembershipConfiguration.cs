using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class MembershipConfiguration : BaseEntityConfiguration<Membership>
    {
        public override void Configure(EntityTypeBuilder<Membership> builder)
        {
            base.Configure(builder);

            builder.Property(membership => membership.StartDate)
                .IsRequired();

            builder.Property(membership => membership.EndDate)
                .IsRequired(false);

            builder.HasOne(membership => membership.Member)
                .WithOne(user => user.Membership)
                .HasForeignKey<Membership>(membership => membership.MemberId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(membership => membership.Loans)
                .WithOne(loan => loan.Membership)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(membership => membership.MembershipType)
               .WithMany(membershipType => membershipType.Membership)
               .HasForeignKey(membership => membership.MembershipTypeId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
