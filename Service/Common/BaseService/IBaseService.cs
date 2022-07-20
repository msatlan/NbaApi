using Model.DAL.Common;
using Model.DTO.Common;

namespace Service.Common.BaseService
{
    public interface IBaseService<TEntity, TDTOModel>
        where TEntity : IBaseEntity
        where TDTOModel : IBaseDTOModel
    {
        public Task<TDTOModel?> GetByIdAsync(Guid id);
        //public Task<IEnumerable<TDTOModel>> GetAllAsync();
        //public Task<bool> AddAsync(TRestModel restModel);
    }
}
