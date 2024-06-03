using DataLayer.API;
using Service.Implementation;

namespace Service.API;

public interface IStateCRUD
{
    static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
    {
        return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddState(int id, int productId, bool available);

    Task<IStateDTO> GetState(int id);

    Task UpdateState(int id, int productId, bool available);

    Task DeleteState(int id);

    Task<Dictionary<int, IStateDTO>> GetAllStates();

    Task<int> GetStatesCount();
}
