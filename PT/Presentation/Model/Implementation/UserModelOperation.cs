using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class UserModelOperation : IUserModelOperation
{
    private IUserCRUD _userCRUD;

    public UserModelOperation(IUserCRUD? userCrud)
    {
        this._userCRUD = userCrud ?? IUserCRUD.CreateUserCRUD();
    }

    private IUserModel Map(IUserDTO user)
    {
        return new UserModel(user.Id, user.FirstName, user.LastName);
    }

    public async Task AddUser(int id, string firstName, string lastName)
    {
        await this._userCRUD.AddUser(id, firstName, lastName);
    }

    public async Task<IUserModel> GetUser(int id)
    {
        return this.Map(await this._userCRUD.GetUser(id));
    }

    public async Task UpdateUser(int id, string firstName, string lastName)
    {
        await this._userCRUD.UpdateUser(id, firstName, lastName);
    }

    public async Task DeleteUser(int id)
    {
        await this._userCRUD.DeleteUser(id);
    }

    public async Task<Dictionary<int, IUserModel>> GetAllUsers()
    {
        Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

        foreach (IUserDTO user in (await this._userCRUD.GetAllUsers()).Values)
        {
            result.Add(user.Id, this.Map(user));
        }

        return result;
    }

    public async Task<int> GetUsersCount()
    {
        return await this._userCRUD.GetUsersCount();
    }
}
