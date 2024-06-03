namespace Service.API;

public interface IStateDTO
{
    int ProductId { get; set; }
    int StateId { get; set; }

    bool Available { get; set; }
}
