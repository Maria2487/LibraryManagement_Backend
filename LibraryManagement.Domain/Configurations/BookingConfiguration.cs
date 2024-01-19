using LibraryManagement.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.HasKey(booking => new { booking.BookId, booking.MembershipId });

            builder.HasOne(booking => booking.Book)
                .WithMany(book => book.Bookings)
                .HasForeignKey(booking => booking.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(booking => booking.Membership)
                .WithMany(membership => membership.Bookings)
                .HasForeignKey(booking => booking.MembershipId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
