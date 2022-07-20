using DAL.Repository.Common.GenericRepository;
using Microsoft.Extensions.Logging;
using Model.DAL.Common;
using System.Linq.Expressions;

namespace DAL.Repository.Common.BaseRepository
{
    public class BaseRepositoryImpl<TEntity> : GenericRepositoryImpl<TEntity>, IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public BaseRepositoryImpl(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await base.GetAll();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, string[]? embed = null)
        {
            var entity = await base.Get(id);

            if (entity != null)
            {
                if (embed is not null)
                {
                    foreach (var item in embed)
                    {
                        context.Entry(entity).Reference(item).Load();
                    }
                }

                return entity;
            }

            return null;
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            var result = await base.Add(entity);

            return result;
        }

        public virtual Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
