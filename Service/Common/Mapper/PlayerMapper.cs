using Model.DAL.EFModel;
using Model.DTO;

namespace Service.Common.Mapper
{
    public class PlayerMapper : IPlayerMapper

    {
        public PlayerDTO Map(Player input)
        {
            try
            {
                return MapProperties(input);
            }
            catch (Exception ex)
            {
                // log ex
                throw;
            }
        }

        public IEnumerable<PlayerDTO> Map(IEnumerable<Player> inputCollection)
        {
            try
            {
                List<PlayerDTO> mappedCollection = new List<PlayerDTO>();

                if (!inputCollection.Any())
                {
                    return mappedCollection;
                }

                foreach (var item in inputCollection)
                {
                    var mappedItem = MapProperties(item);
                    mappedCollection.Add(mappedItem);
                }

                return mappedCollection;
            }
            catch (Exception ex)
            {
                // log ex
                throw;
            }
        }

        private PlayerDTO MapProperties(Player player)
        {
            var newPlayer = new PlayerDTO
            {
                Id = player.Id,
                DateCreated = player.DateCreated,
                DateUpdated = player.DateUpdated,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Position = player.Position.Name,
                Height = player.Height,
                Weight = player.Weight
            };

            return newPlayer;
        }
    }
}

