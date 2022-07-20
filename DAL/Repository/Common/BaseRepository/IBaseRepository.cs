using Model.DAL.Common;
using System.Linq.Expressions;

namespace DAL.Repository.Common.BaseRepository
{
    public interface IBaseRepository<TEntity>
        where TEntity : IBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id, string[]? embed);
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
