using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;

namespace LibraryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IGenreRepository : IBaseEnumRepository<Genre>
    {
    }
}
