using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeUserCRUD : IUserCRUD
    {
        private FakeDataRepository _dataRepository = new FakeDataRepository();

        public async Task AddUser(int id, string firstName, string lastName)
        {
            await this._dataRepository.AddUser(id, firstName, lastName);
        }

        public async Task DeleteUser(int id)
        {
            await this._dataRepository.DeleteUser(id);
        }

        public async Task<Dictionary<int, IUserDTO>> GetAllUsers()
        {
            return await this._dataRepository.GetAllUsers();
        }

        public async Task<IUserDTO> GetUser(int id)
        {
            return await this._dataRepository.GetUser(id);
        }

        public async Task<int> GetUsersCount()
        {
            return await this._dataRepository.GetUsersCount();
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            await this._dataRepository.UpdateUser(id, firstName, lastName);
        }
    }
}
