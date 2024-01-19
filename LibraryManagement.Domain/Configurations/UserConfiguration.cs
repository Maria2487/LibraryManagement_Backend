using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasOne(user => user.Membership)
                .WithOne(membership => membership.Member);

            //builder.HasMany(user => user.Favorites)
            //    .WithOne(favorite => favorite.User)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired(false);

            builder
                .Property(user => user.FirstName)
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(user => user.LastName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(user => user.Email)
                .IsRequired();

            builder
               .Property(entity => entity.Password)
               .IsRequired();

            builder
                .Property(entity => entity.Gender)
                .IsRequired();

            builder
                .Property(entity => entity.Phone)
                .IsRequired();

            builder
                .Property(entity => entity.Role)
                .IsRequired();

            builder
                .Property(entity => entity.DateOfBirth)
                .IsRequired();

            builder
                .Property(entity => entity.Address)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(user => user.MemberPhoto)
                .IsRequired(false);

            builder
                .Property(entity => entity.CreatedAt)
                .IsRequired();

            builder
                .Property(entity => entity.UpdatedAt)
                .IsRequired();
        }
    }
}
