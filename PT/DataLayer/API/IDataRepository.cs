using DataLayer.Implementation;

namespace DataLayer.API
{   //We store all data manipulation methods here for use with Dependency Injection
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(string connectionString)
        {
            return new DataRepository(new DataContext(connectionString));
        }

        Task AddUser(int id, string firstName, string lastName);
        Task<IUser> GetUser(int id);
        Task<IUser> GetUserAsyncMethodSyntax(int id);
        Task UpdateUser(int id, string firstName, string lastName);
        Task DeleteUser(int id);
        Task<Dictionary<int, IUser>> GetAllUsers();
        Task<int> GetUsersCount();

        Task AddProduct(int id, string name, string description, float price);
        Task<IProduct> GetProduct(int id);
        Task UpdateProduct(int id, string name, string description, float price);
        Task DeleteProduct(int id);
        Task<Dictionary<int, IProduct>> GetAllProducts();
        Task<int> GetProductsCount();

        Task AddState(int id, int productId, bool available);
        Task<IState> GetState(int id);
        Task UpdateState(int id, int productId, bool available);
        Task DeleteState(int id);
        Task<Dictionary<int, IState>> GetAllStates();
        Task<int> GetStatesCount();

        Task AddEvent(int id, int stateId, int userId, string type);
        Task<IEvent> GetEvent(int id);
        Task UpdateEvent(int id, int stateId, int userId, string type);
        Task DeleteEvent(int id);
        Task<Dictionary<int, IEvent>> GetAllEvents();
        Task<int> GetEventsCount();
    }
}