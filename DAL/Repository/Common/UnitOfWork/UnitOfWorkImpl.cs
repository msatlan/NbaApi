
using DAL.Repository.PlayerRepository;
using Microsoft.Extensions.Logging;

namespace DAL.Repository.Common.UnitOfWork
{
    public class UnitOfWorkImpl : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<UnitOfWorkImpl> logger;

        #region Repositories
        public IPlayerRepository PlayerRepository { get; private set; }
        #endregion 

        public UnitOfWorkImpl(ApplicationDbContext context, ILogger<UnitOfWorkImpl> logger)
        {
            this.context = context;
            this.logger = logger;
            PlayerRepository = new PlayerRepositoryImpl(context, logger);
        }

        public async Task<bool> CommitAsync()
        {
           return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
            //GC.SuppressFinalize(this);
        }
    }
}
