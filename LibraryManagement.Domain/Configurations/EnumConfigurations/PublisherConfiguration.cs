using LibraryManagement.Domain.Configurations.Base;
using LibraryManagement.Domain.Entities.EnumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations.EnumConfigurations
{
    public class PublisherConfiguration : BaseEnumConfiguration<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> builder)
        {
            base.Configure(builder);

            builder.HasMany(publisher => publisher.Books)
                .WithOne(book => book.Publisher)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
