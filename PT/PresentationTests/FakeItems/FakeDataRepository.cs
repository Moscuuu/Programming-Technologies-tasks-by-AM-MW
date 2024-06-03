using Presentation.Model.API;

namespace PresentationTests.FakeItems;

internal class FakeDataRepository
{
    public Dictionary<int, IUserModel> Users = new Dictionary<int, IUserModel>();

    public Dictionary<int, IProductModel> Products = new Dictionary<int, IProductModel>();

    public Dictionary<int, IEventModel> Events = new Dictionary<int, IEventModel>();

    public Dictionary<int, IStateModel> States = new Dictionary<int, IStateModel>();


    public async Task AddUser(int id, string firstName, string lastName)
    {
        this.Users.Add(id, new FakeUserDTO(id, firstName, lastName));
    }

    public async Task<IUserModel> GetUser(int id)
    {
        return await Task.FromResult(this.Users[id]);
    }

    public async Task UpdateUser(int id, string firstName, string lastName)
    {
        this.Users[id].FirstName = firstName;
        this.Users[id].LastName = lastName;
    }

    public async Task DeleteUser(int id)
    {
        this.Users.Remove(id);
    }

    public async Task<Dictionary<int, IUserModel>> GetAllUsers()
    {
        return await Task.FromResult(this.Users);
    }

    public async Task<int> GetUsersCount()
    {
        return await Task.FromResult(this.Users.Count);
    }

    public bool CheckIfUserExists(int id)
    {
        return this.Users.ContainsKey(id);
    }




    public async Task AddProduct(int id, string name, string description, float price)
    {
        this.Products.Add(id, new FakeProductDTO(id, name, description, price));
    }

    public async Task<IProductModel> GetProduct(int id)
    {
        return await Task.FromResult(this.Products[id]);
    }

    public async Task UpdateProduct(int id, string name, string description, float price)
    {
        this.Products[id].ProductName = name;
        this.Products[id].ProductDescription = description;
        this.Products[id].Price = price;
    }

    public async Task DeleteProduct(int id)
    {
        this.Products.Remove(id);
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProducts()
    {
        return await Task.FromResult(this.Products);
    }

    public async Task<int> GetProductsCount()
    {
        return await Task.FromResult(this.Products.Count);
    }




    public async Task AddState(int id, int productId, bool available)
    {
        this.States.Add(id, new FakeStateDTO(id, productId, available));
    }

    public async Task<IStateModel> GetState(int id)
    {
        return await Task.FromResult(this.States[id]);
    }

    public async Task UpdateState(int id, int productId, bool available)
    {
        this.States[id].ProductId = productId;
        this.States[id].Available = available;
    }

    public async Task DeleteState(int id)
    {
        this.States.Remove(id);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStates()
    {
        return await Task.FromResult(this.States);
    }

    public async Task<int> GetStatesCount()
    {
        return await Task.FromResult(this.States.Count);
    }




    public async Task AddEvent(int id, int stateId, int userId, string type)
    {
        this.Events.Add(id, new FakeEventDTO(id, stateId, userId, type));
    }

    public async Task<IEventModel> GetEvent(int id)
    {
        return await Task.FromResult(this.Events[id]);
    }

    public async Task UpdateEvent(int id, int stateId, int userId, string type)
    {
        ((FakeEventDTO)this.Events[id]).StateId = stateId;
        ((FakeEventDTO)this.Events[id]).UserId = userId;
        ((FakeEventDTO)this.Events[id]).Type = type;
    }

    public async Task DeleteEvent(int id)
    {
        this.Events.Remove(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllEvents()
    {
        return await Task.FromResult(this.Events);
    }

    public async Task<int> GetEventsCount()
    {
        return await Task.FromResult(this.Events.Count);
    }

}