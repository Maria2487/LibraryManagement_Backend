using LibraryManagement.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(bookGenre => new { bookGenre.BookId, bookGenre.GenreId });

            builder.HasOne(bookGenre => bookGenre.Book)
                .WithMany(book => book.Genres)
                .HasForeignKey(bookGenre => bookGenre.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bookGenre => bookGenre.Genre)
                .WithMany(genre => genre.Books)
                .HasForeignKey(bookGenre => bookGenre.GenreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
