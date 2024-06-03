using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeStateCRUD : IStateCRUD
    {
        private FakeDataRepository _dataRepository = new FakeDataRepository();

        public async Task AddState(int id, int productId, bool available)
        {
            await _dataRepository.AddState(id, productId, available);
        }

        public async Task DeleteState(int id)
        {
            await _dataRepository.DeleteState(id);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStates()
        {
            return await _dataRepository.GetAllStates();
        }

        public async Task<IStateDTO> GetState(int id)
        {
            return await _dataRepository.GetState(id);
        }

        public async Task<int> GetStatesCount()
        {
            return await _dataRepository.GetStatesCount();
        }

        public async Task UpdateState(int id, int productId, bool available)
        {
            await _dataRepository.UpdateState(id, productId, available);
        }
    }
}
