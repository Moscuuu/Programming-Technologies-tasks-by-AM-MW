using Presentation.Model.API;

namespace Presentation.Model.Implementation;

internal class StateModel : IStateModel
{
    public int StateId { get; set; }

    public int ProductId { get; set; }

    public bool Available { get; set; }

    public StateModel(int stateid, int productId, bool available)
    {
        this.StateId = stateid;
        this.ProductId = productId;
        this.Available = available;
    }
}
