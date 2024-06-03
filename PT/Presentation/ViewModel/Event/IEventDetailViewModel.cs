using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IEventDetailViewModel
{
    static IEventDetailViewModel CreateViewModel(int id, int stateId, int userId,
        string type, IEventModelOperation model, IErrorInformer informer)
    {
        return new EventDetailViewModel(id, stateId, userId, type, model, informer);
    }

    ICommand UpdateEvent { get; set; }

    int Id { get; set; }

    int StateId { get; set; }

    int UserId { get; set; }

    DateTime EventDate { get; set; }

    string Type { get; set; }
}
