using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.EnumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations.EnumConfigurations
{
    public class GenreConfiguration : BaseEnumConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.HasMany(genre => genre.Books)
                .WithOne(book => book.Genre)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
