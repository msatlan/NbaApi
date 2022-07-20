using Model.DTO.Common;

namespace Model.DTO

{
    public class PlayerDTO : BaseDTOModel, IPlayerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string? Position { get; set; }
    }
}
