using DataLayer.API;
using Service.Implementation;


namespace Service.API;

public interface IUserCRUD
{
    static IUserCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
    {
        return new UserCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddUser(int id, string firstName, string lastName);

    Task<IUserDTO> GetUser(int id);

    Task UpdateUser(int id, string firstName, string lastName);

    Task DeleteUser(int id);

    Task<Dictionary<int, IUserDTO>> GetAllUsers();

    Task<int> GetUsersCount();
}
