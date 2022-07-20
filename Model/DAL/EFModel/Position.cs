using Model.DAL.Common;

namespace Model.DAL.EFModel
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
