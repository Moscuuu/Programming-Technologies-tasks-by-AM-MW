using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeEventCRUD : IEventCRUD
    {
        private FakeDataRepository _dataRepository = new FakeDataRepository();

        public async Task AddEvent(int id, int stateId, int userId, string type)
        {
            await _dataRepository.AddEvent(id, stateId, userId, type);
        }

        public async Task DeleteEvent(int id)
        {
            await _dataRepository.DeleteEvent(id);
        }

        public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
        {
            return await _dataRepository.GetAllEvents();
        }

        public async Task<IEventDTO> GetEvent(int id)
        {
            return await _dataRepository.GetEvent(id);
        }

        public async Task<int> GetEventsCount()
        {
            return await _dataRepository.GetEventsCount();
        }

        public async Task UpdateEvent(int id, int stateId, int userId, string type)
        {
            await _dataRepository.UpdateEvent(id, stateId, userId, type);
        }
    }
}
