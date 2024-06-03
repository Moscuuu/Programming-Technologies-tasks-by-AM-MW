using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }


        public async Task AddUser(int id, string firstName, string lastName)
        {
            IUser user = new User(id, firstName, lastName);

            await this._context.AddUser(user);
        }

        public async Task<IUser> GetUser(int id)
        {
            IUser? user = await this._context.GetUserAsyncQuerySyntax(id);

            if (user is null)
                throw new Exception("This user does not exist!");

            return user;
        }

        public async Task<IUser> GetUserAsyncMethodSyntax(int id)
        {
            IUser? user = await this._context.GetUserAsyncMethodSyntax(id);

            if (user is null)
                throw new Exception("This user does not exist!");

            return user;
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            IUser user = new User(id, firstName, lastName);

            if (!await this.CheckIfUserExists(user.id))
                throw new Exception("This user does not exist");

            await this._context.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            if (!await this.CheckIfUserExists(id))
                throw new Exception("This user does not exist");

            await this._context.DeleteUser(id);
        }

        public async Task<Dictionary<int, IUser>> GetAllUsers()
        {
            return await this._context.GetAllUsers();
        }

        public async Task<int> GetUsersCount()
        {
            return await this._context.GetUsersCount();
        }




        public async Task AddProduct(int id, string name, string description, float price)
        {
            IProduct product = new Product(id, name, description, price);

            await this._context.AddProduct(product);
        }

        public async Task<IProduct> GetProduct(int id)
        {
            IProduct? product = await this._context.GetProduct(id);

            if (product is null)
                throw new Exception("This product does not exist!");

            return product;
        }

        public async Task UpdateProduct(int id, string name, string description, float price)
        {
            IProduct product = new Product(id, name, description, price);

            if (!await this.CheckIfProductExists(product.id))
                throw new Exception("This product does not exist");

            await this._context.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            if (!await this.CheckIfProductExists(id))
                throw new Exception("This product does not exist");

            await this._context.DeleteProduct(id);
        }

        public async Task<Dictionary<int, IProduct>> GetAllProducts()
        {
            return await this._context.GetAllProducts();
        }

        public async Task<int> GetProductsCount()
        {
            return await this._context.GetProductsCount();
        }




        public async Task AddState(int id, int productId, bool available)
        {
            if (!await this._context.CheckIfProductExists(productId))
                throw new Exception("This product does not exist!");

            IState state = new State(id, productId, available);

            await this._context.AddState(state);
        }

        public async Task<IState> GetState(int id)
        {
            IState? state = await this._context.GetState(id);

            if (state is null)
                throw new Exception("This state does not exist!");

            return state;
        }

        public async Task UpdateState(int id, int productId, bool available)
        {
            if (!await this._context.CheckIfProductExists(productId))
                throw new Exception("This product does not exist!");

            IState state = new State(id, productId, available);

            if (!await this.CheckIfStateExists(state.stateId))
                throw new Exception("This state does not exist");

            await this._context.UpdateState(state);
        }

        public async Task DeleteState(int id)
        {
            if (!await this.CheckIfStateExists(id))
                throw new Exception("This state does not exist");

            await this._context.DeleteState(id);
        }

        public async Task<Dictionary<int, IState>> GetAllStates()
        {
            return await this._context.GetAllStates();
        }

        public async Task<int> GetStatesCount()
        {
            return await this._context.GetStatesCount();
        }




        public async Task AddEvent(int id, int stateId, int userId, string type)
        {

            IUser user = await this.GetUser(userId);
            IState state = await this.GetState(stateId);
            IProduct product = await this.GetProduct(state.productId);

            IEvent newEvent = new Event(id, stateId, userId, type);

            await this._context.AddEvent(newEvent);
        }

        public async Task<IEvent> GetEvent(int id)
        {
            IEvent? even = await this._context.GetEvent(id);

            if (even is null)
                throw new Exception("This event does not exist!");

            return even;
        }

        public async Task UpdateEvent(int id, int stateId, int userId, string type)
        {
            IEvent newEvent = new Event(id, stateId, userId, type);

            if (!await this.CheckIfEventExists(newEvent.eventId))
                throw new Exception("This event does not exist");

            await this._context.UpdateEvent(newEvent);
        }

        public async Task DeleteEvent(int id)
        {
            if (!await this.CheckIfEventExists(id))
                throw new Exception("This event does not exist");

            await this._context.DeleteEvent(id);
        }

        public async Task<Dictionary<int, IEvent>> GetAllEvents()
        {
            return await this._context.GetAllEvents();
        }

        public async Task<int> GetEventsCount()
        {
            return await this._context.GetEventsCount();
        }




        public async Task<bool> CheckIfUserExists(int id)
        {
            return await this._context.CheckIfUserExists(id);
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return await this._context.CheckIfProductExists(id);
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return await this._context.CheckIfStateExists(id);
        }

        public async Task<bool> CheckIfEventExists(int id)
        {
            return await this._context.CheckIfEventExists(id);
        }
    }
}
