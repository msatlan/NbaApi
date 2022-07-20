using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.DAL.Common;
using System.Linq.Expressions;

namespace DAL.Repository.Common.GenericRepository
{
    public class GenericRepositoryImpl<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;
        protected readonly ILogger logger;

        public GenericRepositoryImpl(ApplicationDbContext context, ILogger logger)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
            this.logger = logger;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);

            return true;
        }

        public virtual bool Delete(TEntity entity)
        {
            dbSet.Remove(entity);

            return true;
        }

        public virtual async Task<IEnumerable<TEntity>?> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual bool Update(TEntity entity)
        {
            dbSet.Update(entity);

            return true;
        }

    }
}
