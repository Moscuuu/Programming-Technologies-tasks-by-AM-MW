namespace Service.API;

public interface IEventDTO
{
    int Id { get; set; }
    int StateId { get; set; }
    int UserId { get; set; }
    DateTime EventDate { get; }
    string Type { get; set; }
}
