using Presentation.Model.API;

namespace Presentation.Model.Implementation;

internal class UserModel : IUserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public UserModel(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}
