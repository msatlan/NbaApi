using DAL.Repository.Common.BaseRepository;
using Microsoft.Extensions.Logging;
using Model.DAL.EFModel;

namespace DAL.Repository.PlayerRepository
{
    public class PlayerRepositoryImpl : BaseRepositoryImpl<Player>, IPlayerRepository
    {
        public PlayerRepositoryImpl(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
