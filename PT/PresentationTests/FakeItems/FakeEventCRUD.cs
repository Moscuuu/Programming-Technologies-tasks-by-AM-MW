using Presentation.Model.API;

namespace PresentationTests.FakeItems
{
    internal class FakeEventCRUD : IEventModelOperation
    {
        private readonly FakeDataRepository _testRepository = new FakeDataRepository();

        public FakeEventCRUD()
        {
        }

        public async Task AddEvent(int id, int stateId, int userId, string type)
        {
            await this._testRepository.AddEvent(id, stateId, userId, type);
        }

        public async Task<IEventModel> GetEvent(int id, string type)
        {
            return await this._testRepository.GetEvent(id);
        }

        public async Task UpdateEvent(int id, int stateId, int userId, string type)
        {
            await this._testRepository.UpdateEvent(id, stateId, userId, type);
        }

        public async Task DeleteEvent(int id)
        {
            await this._testRepository.DeleteEvent(id);
        }

        public async Task<Dictionary<int, IEventModel>> GetAllEvents()
        {
            Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

            foreach (IEventModel currentEvent in (await this._testRepository.GetAllEvents()).Values)
            {
                result.Add(currentEvent.Id, (IEventModel)currentEvent);
            }

            return result;
        }

        public async Task<int> GetEventsCount()
        {
            return await this._testRepository.GetEventsCount();
        }
    }
}
