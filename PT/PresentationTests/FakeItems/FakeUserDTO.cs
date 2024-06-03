using Presentation.Model.API;

namespace PresentationTests.FakeItems
{
    internal class FakeUserDTO : IUserModel
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
