using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class UserCRUD : IUserCRUD
{
    private IDataRepository _repository;

    public UserCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    private IUserDTO Map(IUser user)
    {
        return new UserDTO(user.id, user.firstName, user.lastName);
    }

    public async Task AddUser(int id, string firstName, string lastName)
    {
        await this._repository.AddUser(id, firstName, lastName);
    }

    public async Task<IUserDTO> GetUser(int id)
    {
        return this.Map(await this._repository.GetUser(id));
    }

    public async Task UpdateUser(int id, string firstName, string lastName)
    {
        await this._repository.UpdateUser(id, firstName, lastName);
    }

    public async Task DeleteUser(int id)
    {
        await this._repository.DeleteUser(id);
    }

    public async Task<Dictionary<int, IUserDTO>> GetAllUsers()
    {
        Dictionary<int, IUserDTO> result = new Dictionary<int, IUserDTO>();

        foreach (IUser user in (await this._repository.GetAllUsers()).Values)
        {
            result.Add(user.id, this.Map(user));
        }

        return result;
    }

    public async Task<int> GetUsersCount()
    {
        return await this._repository.GetUsersCount();
    }
}
