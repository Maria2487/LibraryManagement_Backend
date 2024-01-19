using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(book => book.Edition)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(book => book.PublishDate)
                .IsRequired();

            builder.Property(book => book.Language)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(book => book.Description)
                .IsRequired(false);

            builder.Property(book => book.CoverPhoto)
                .IsRequired();

            builder.Property(book => book.Status)
                .IsRequired();

            builder.HasOne(book => book.Publisher)
                .WithMany(publisher => publisher.Books)
                .HasForeignKey(book => book.PublisherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(book => book.Loans)
                .WithOne(loan => loan.Book)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(book => book.Genres)
                .WithOne(genre => genre.Book)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(book => book.Authors)
                .WithOne(author => author.Book)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            //builder.HasMany(book => book.Favorites)
            //    .WithOne(favorite => favorite.Book)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired(false);
        }
    }
}
