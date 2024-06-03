using Presentation.Model.API;

namespace PresentationTests.FakeItems
{
    internal class FakeStateCRUD : IStateModelOperation
    {
        private readonly FakeDataRepository _testRepository = new FakeDataRepository();

        public FakeStateCRUD()
        {
        }


        public async Task AddState(int id, int productId, bool available)
        {
            await _testRepository.AddState(id, productId, available);
        }

        public async Task<IStateModel> GetState(int id)
        {
            return await this._testRepository.GetState(id);
        }

        public async Task UpdateState(int id, int productId, bool available)
        {
            await this._testRepository.UpdateState(id, productId, available);
        }

        public async Task DeleteState(int id)
        {
            await this._testRepository.DeleteState(id);
        }

        public async Task<Dictionary<int, IStateModel>> GetAllStates()
        {
            Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

            foreach (IStateModel state in (await this._testRepository.GetAllStates()).Values)
            {
                result.Add(state.StateId, (IStateModel)state);
            }

            return result;
        }

        public async Task<int> GetStatesCount()
        {
            return await this._testRepository.GetStatesCount();
        }
    }
}
