namespace Model.DTO.Common
{
    public class BaseDTOModel : IBaseDTOModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
