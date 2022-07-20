using DAL.Repository.Common.UnitOfWork;
using Model.DTO;
using Service.Common.Mapper;

namespace Service.PlayerService
{
    public class PlayerServiceImpl : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPlayerMapper mapper;

        public PlayerServiceImpl(IUnitOfWork unitOfWork, IPlayerMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //public async Task<bool> AddAsync(PlayerRestModel playerRestModel)
        //{
        //try
        //{
        //    var player = PlayerMapper.MapRestModelToEntity(playerRestModel);
        //    var result = await UnitOfWork.PlayerRepository.InsertAsync(player);

        //    try
        //    {
        //        await UnitOfWork.CommitAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return result;
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
        //return false;
        // }

        public async Task<IEnumerable<PlayerDTO>> GetAllAsync()
        {
            try
            {
                var players = await unitOfWork.PlayerRepository.GetAllAsync();

                return mapper.Map(players);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // id = 727d5613-2312-4f84-b952-e7e3b4a19600
        public async Task<PlayerDTO?> GetByIdAsync(Guid id, string? embed)
        {
            try
            {
                string[]? embedList = null;

                if (embed is not null)
                {
                    embedList = embed.Split(',');
                }

                var player = await unitOfWork.PlayerRepository.GetByIdAsync(id, embedList);

                if (player is null)
                {
                    return null;
                }

                return mapper.Map(player);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
