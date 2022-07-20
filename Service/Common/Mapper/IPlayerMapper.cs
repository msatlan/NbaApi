using Model.DAL.EFModel;
using Model.DTO;

namespace Service.Common.Mapper
{
    public interface IPlayerMapper
    {
        PlayerDTO Map(Player input);

        IEnumerable<PlayerDTO> Map(IEnumerable<Player> inputCollection);
    }
}
