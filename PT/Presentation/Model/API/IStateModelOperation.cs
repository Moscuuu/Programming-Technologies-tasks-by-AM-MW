using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IStateModelOperation
{
    static IStateModelOperation CreateModelOperation(IStateCRUD? stateCrud = null)
    {
        return new StateModelOperation(stateCrud ?? IStateCRUD.CreateStateCRUD());
    }

    Task AddState(int stateid, int productId, bool available);

    Task<IStateModel> GetState(int stateid);

    Task UpdateState(int stateid, int productId, bool available);

    Task DeleteState(int stateid);

    Task<Dictionary<int, IStateModel>> GetAllStates();

    Task<int> GetStatesCount();
}
