namespace DataLayer.API
{
    public interface IState
    {
        int productId { get; set; }
        int stateId { get; set; }

        bool available { get; set; }
    }
}
