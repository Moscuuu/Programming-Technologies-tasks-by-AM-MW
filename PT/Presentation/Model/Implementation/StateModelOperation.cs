using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class StateModelOperation : IStateModelOperation
{
    private IStateCRUD _stateCrud;

    public StateModelOperation(IStateCRUD? stateCrud = null)
    {
        this._stateCrud = stateCrud ?? IStateCRUD.CreateStateCRUD();
    }

    private IStateModel Map(IStateDTO state)
    {
        return new StateModel(state.StateId, state.ProductId, state.Available);
    }

    public async Task AddState(int stateId, int productId, bool available)
    {
        await this._stateCrud.AddState(stateId, productId, available);
    }

    public async Task<IStateModel> GetState(int stateId)
    {
        return this.Map(await this._stateCrud.GetState(stateId));
    }

    public async Task UpdateState(int stateId, int productId, bool available)
    {
        await this._stateCrud.UpdateState(stateId, productId, available);
    }

    public async Task DeleteState(int stateId)
    {
        await this._stateCrud.DeleteState(stateId);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStates()
    {
        Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

        foreach (IStateDTO state in (await this._stateCrud.GetAllStates()).Values)
        {
            result.Add(state.StateId, this.Map(state));
        }

        return result;
    }

    public async Task<int> GetStatesCount()
    {
        return await this._stateCrud.GetStatesCount();
    }
}
