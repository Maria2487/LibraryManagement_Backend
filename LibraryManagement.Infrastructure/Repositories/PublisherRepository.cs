using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Base;
using LibraryManagement.Infrastructure.Repositories.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class PublisherRepository : BaseEnumRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
