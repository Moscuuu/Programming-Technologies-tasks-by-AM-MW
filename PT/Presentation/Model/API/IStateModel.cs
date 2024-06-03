namespace Presentation.Model.API;

public interface IStateModel
{
    int StateId { get; set; }

    int ProductId { get; set; }

    bool Available { get; set; }
}
