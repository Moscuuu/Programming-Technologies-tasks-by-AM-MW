using Service.API;

namespace Service.Implementation;

internal class UserDTO : IUserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set; }

    public UserDTO(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;

    }
}
