using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeUserDTO : IUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public FakeUserDTO(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }
}
