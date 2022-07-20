using Model.DAL.Common;

namespace Model.DAL.EFModel
{
    public class Player : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Position Position { get; set; }
        public Guid PositionId { get; set; }
    }
}
