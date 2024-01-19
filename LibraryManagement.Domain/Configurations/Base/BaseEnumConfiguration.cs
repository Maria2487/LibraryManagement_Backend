using LibraryManagement.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Domain.Configurations.Base
{
    public class BaseEnumConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEnumEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Name)
                .IsRequired();
        }
    }
}
