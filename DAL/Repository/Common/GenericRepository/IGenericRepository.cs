using Model.DAL.Common;
using System.Linq.Expressions;

namespace DAL.Repository.Common.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity?> Get(Guid Id);

        Task<bool> Add(TEntity entity);

        bool Delete(TEntity entity);

        bool Update(TEntity entity);

        Task<IEnumerable<TEntity>?> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
