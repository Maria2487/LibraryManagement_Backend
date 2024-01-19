namespace LibraryManagement.Infrastructure.Repositories.Interfaces.Base
{
    public interface IBaseEntityRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity?> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllByDeletedStatus(bool isDeleted);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
