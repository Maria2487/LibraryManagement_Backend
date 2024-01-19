using LibraryManagement.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(bookAuthor => new { bookAuthor.BookId, bookAuthor.AuthorId });

            builder.HasOne(bookAuthor => bookAuthor.Book)
                .WithMany(book => book.Authors)
                .HasForeignKey(bookAuthor => bookAuthor.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bookAuthor => bookAuthor.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(bookAuthor => bookAuthor.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
