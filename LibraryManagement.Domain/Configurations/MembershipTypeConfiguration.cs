using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class MembershipTypeConfiguration : BaseEnumConfiguration<MembershipType>
    {
        public override void Configure(EntityTypeBuilder<MembershipType> builder)
        {
            base.Configure(builder);

            builder.Property(membershipType => membershipType.Name)
                .IsRequired(true);

            builder.Property(membershipType => membershipType.NumberOfLoansAllowed)
                .IsRequired();

            builder.Property(membershipType => membershipType.NumberOfLoansNeeded)
               .IsRequired();

            builder.Property(membershipType => membershipType.Badge)
                .IsRequired(false);

            builder.Property(membershipType => membershipType.Price)
                .IsRequired();

            //builder.HasOne(membershipType => membershipType.Membership)
            //    .WithMany(membership => membership.MembershipType)
            //    .HasForeignKey(membershipType => membershipType.Membership)
            //    .OnDelete(DeleteBehavior.NoAction);
    }
    }
}
