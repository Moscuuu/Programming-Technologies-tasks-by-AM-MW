using Presentation.Model.API;

namespace PresentationTests.FakeItems
{
    internal class FakeUserCRUD : IUserModelOperation
    {
        private readonly FakeDataRepository _testRepository = new FakeDataRepository();

        public FakeUserCRUD() { }

        public async Task AddUser(int id, string firstName, string lastName)
        {
            await _testRepository.AddUser(id, firstName, lastName);
        }

        public async Task<IUserModel> GetUser(int id)
        {
            return await _testRepository.GetUser(id);
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            await _testRepository.UpdateUser(id, firstName, lastName);
        }

        public async Task DeleteUser(int id)
        {
            await _testRepository.DeleteUser(id);
        }

        public async Task<Dictionary<int, IUserModel>> GetAllUsers()
        {
            Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

            foreach (IUserModel user in (await _testRepository.GetAllUsers()).Values)
            {
                result.Add(user.Id, user);
            }

            return result;
        }

        public async Task<int> GetUsersCount()
        {
            return await _testRepository.GetUsersCount();
        }

    }
}
