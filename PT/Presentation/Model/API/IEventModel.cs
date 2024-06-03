namespace Presentation.Model.API;

public interface IEventModel
{
    int Id { get; set; }

    int StateId { get; set; }

    int UserId { get; set; }

    DateTime EventDate { get; set; }

    string Type { get; set; }

}
