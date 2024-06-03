using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class User : IUser
    {
        public User(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int id { get; set; }
    }
}
