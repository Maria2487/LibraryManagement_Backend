using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.Property(author => author.FirstName)
                .IsRequired(false);

            builder.Property(author => author.LastName)
                .IsRequired(false);

            builder.Property(author => author.DateOfBirth)
                .IsRequired(false);

            builder.Property(author => author.DateOfDeath)
                .IsRequired(false);

            builder.Property(author => author.Nationality)
                .IsRequired(false);

            builder.Property(author => author.Biography)
                .IsRequired();

            builder.Property(author => author.Photo)
                .IsRequired(false);

            builder.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
