namespace LibraryManagement.Infrastructure.Repositories.Interfaces.Base
{
    public interface IBaseEnumRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity?> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
