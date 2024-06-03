using DataLayer.Implementation;

namespace DataLayer.API
{
    public interface IDataContext
    {

        static IDataContext CreateContext(string? connectionString = null)
        {
            return new DataContext(connectionString);
        }

        Task AddUser(IUser user);
        Task<IUser?> GetUserAsyncQuerySyntax(int id);
        Task<IUser?> GetUserAsyncMethodSyntax(int id);
        Task UpdateUser(IUser user);
        Task DeleteUser(int id);
        Task<Dictionary<int, IUser>> GetAllUsers();
        Task<int> GetUsersCount();

        Task AddProduct(IProduct product);
        Task<IProduct?> GetProduct(int id);
        Task UpdateProduct(IProduct product);
        Task DeleteProduct(int id);
        Task<Dictionary<int, IProduct>> GetAllProducts();
        Task<int> GetProductsCount();

        Task AddState(IState state);
        Task<IState?> GetState(int id);
        Task UpdateState(IState state);
        Task DeleteState(int id);
        Task<Dictionary<int, IState>> GetAllStates();
        Task<int> GetStatesCount();

        Task AddEvent(IEvent even);
        Task<IEvent?> GetEvent(int id);
        Task UpdateEvent(IEvent even);
        Task DeleteEvent(int id);
        Task<Dictionary<int, IEvent>> GetAllEvents();
        Task<int> GetEventsCount();

        Task<bool> CheckIfUserExists(int id);
        Task<bool> CheckIfProductExists(int id);
        Task<bool> CheckIfStateExists(int id);
        Task<bool> CheckIfEventExists(int id);
    }
}
