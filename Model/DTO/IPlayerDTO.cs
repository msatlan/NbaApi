namespace Model.DTO
{
    public interface IPlayerDTO
    {
        string? FirstName { get; set; }
        string? LastName { get; set; }
        int Height { get; set; }
        int Weight { get; set; }
        string? Position { get; set; }
    }
}
