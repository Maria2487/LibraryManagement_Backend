using LibraryManagement.Domain.Entities.Base;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagement.Infrastructure.Repositories.Base
{
    public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseEntityRepository(ApplicationDbContext applicationDbContext)
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
            entity.IsDeleted = true;
            await applicationDbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllByDeletedStatus(bool isDeleted)
        {
            return await dbSet
                .Where(entity => entity.IsDeleted == false)
                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            dbSet.Update(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var query = dbSet.AsNoTracking().AsQueryable();
            //query = query.Where(entity => entity.IsDeleted == false);
            query = filter != null ? query.Where(filter) : query;

            return query;
        }
    }
}
