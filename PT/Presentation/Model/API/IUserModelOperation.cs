using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IUserModelOperation
{
    static IUserModelOperation CreateModelOperation(IUserCRUD userCrud = null)
    {
        return new UserModelOperation(userCrud);
    }

    Task AddUser(int id, string firstName, string lastName);

    Task<IUserModel> GetUser(int id);

    Task UpdateUser(int id, string firstName, string lastName);

    Task DeleteUser(int id);

    Task<Dictionary<int, IUserModel>> GetAllUsers();

    Task<int> GetUsersCount();
}
