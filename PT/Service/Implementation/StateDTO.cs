using Service.API;

namespace Service.Implementation;

internal class StateDTO : IStateDTO
{
    public int ProductId { get; set; }
    public int StateId { get; set; }

    public bool Available { get; set; }

    public StateDTO(int id, int productId, bool available)
    {
        this.StateId = id;
        this.ProductId = productId;
        this.Available = available;
    }
}
