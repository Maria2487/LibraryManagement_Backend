using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories.Base
{
    public class BaseEnumRepository<TEntity> : IBaseEnumRepository<TEntity> where TEntity : BaseEnumEntity
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseEnumRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            dbSet.Update(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
