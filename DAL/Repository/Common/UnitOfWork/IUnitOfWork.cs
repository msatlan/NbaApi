using DAL.Repository.PlayerRepository;

namespace DAL.Repository.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlayerRepository PlayerRepository { get; }

        Task<bool> CommitAsync();
        void Dispose();

    }
}
