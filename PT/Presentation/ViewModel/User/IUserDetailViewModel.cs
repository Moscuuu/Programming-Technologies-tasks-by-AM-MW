using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public interface IUserDetailViewModel
    {
        static IUserDetailViewModel CreateViewModel(int id, string firstName, string lastName, IUserModelOperation model, IErrorInformer informer)
        {
            return new UserDetailViewModel(id, firstName, lastName, model, informer);
        }

        ICommand UpdateUser { get; set; }

        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

    }
}
