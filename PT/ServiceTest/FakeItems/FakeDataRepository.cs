using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeDataRepository
    {
        public Dictionary<int, IUserDTO> Users = new Dictionary<int, IUserDTO>();

        public Dictionary<int, IProductDTO> Products = new Dictionary<int, IProductDTO>();

        public Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

        public Dictionary<int, IEventDTO> Events = new Dictionary<int, IEventDTO>();

        public async Task AddEvent(int id, int stateId, int userId, string type)
        {
            Events.Add(id, new FakeEventDTO(id, stateId, userId, type));
        }

        public async Task AddProduct(int id, string name, string description, float price)
        {
            Products.Add(id, new FakeProductDTO(id, name, description, price));
        }

        public async Task AddState(int id, int productId, bool available)
        {
            States.Add(id, new FakeStateDTO(id, productId, available));
        }

        public async Task AddUser(int id, string firstName, string lastName)
        {
            Users.Add(id, new FakeUserDTO(id, firstName, lastName));
        }

        public async Task DeleteEvent(int id)
        {
            Events.Remove(id);
        }

        public async Task DeleteProduct(int id)
        {
            Products.Remove(id);
        }

        public async Task DeleteState(int id)
        {
            States.Remove(id);
        }

        public async Task DeleteUser(int id)
        {
            Users.Remove(id);
        }

        public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
        {
            return await Task.FromResult(Events);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
        {
            return await Task.FromResult(Products);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStates()
        {
            return await Task.FromResult(States);
        }

        public async Task<Dictionary<int, IUserDTO>> GetAllUsers()
        {
            return await Task.FromResult(Users);
        }

        public async Task<IEventDTO> GetEvent(int id)
        {
            return await Task.FromResult(Events[id]);
        }

        public async Task<int> GetEventsCount()
        {
            return await Task.FromResult(Events.Count);
        }

        public async Task<IProductDTO> GetProduct(int id)
        {
            return await Task.FromResult(Products[id]);
        }

        public async Task<int> GetProductsCount()
        {
            return await Task.FromResult(Products.Count);
        }

        public async Task<IStateDTO> GetState(int id)
        {
            return await Task.FromResult(States[id]);
        }

        public async Task<int> GetStatesCount()
        {
            return await Task.FromResult(States.Count);
        }

        public async Task<IUserDTO> GetUser(int id)
        {
            return await Task.FromResult(Users[id]);
        }

        public async Task<int> GetUsersCount()
        {
            return await Task.FromResult(Users.Count);
        }

        public async Task UpdateEvent(int id, int stateId, int userId, string type)
        {
            Events[id].StateId = stateId;
            Events[id].UserId = userId;
            Events[id].Type = type;
        }

        public async Task UpdateProduct(int id, string name, string description, float price)
        {
            Products[id].Author = name;
            Products[id].ProductDescription = description;
            Products[id].Price = price;
        }

        public async Task UpdateState(int id, int productId, bool available)
        {
            States[id].ProductId = productId;
            States[id].Available = available;
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            Users[id].FirstName = firstName;
            Users[id].LastName = lastName;
        }
    }
}
