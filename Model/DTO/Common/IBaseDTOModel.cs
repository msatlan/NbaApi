namespace Model.DTO.Common
{
    public interface IBaseDTOModel
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
