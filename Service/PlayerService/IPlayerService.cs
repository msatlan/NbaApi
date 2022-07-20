using Model.DTO;

namespace Service.PlayerService
{
    public interface IPlayerService
    {
        Task<PlayerDTO?> GetByIdAsync(Guid id, string? embed);

        Task<IEnumerable<PlayerDTO>> GetAllAsync();
    }
}
