using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IEventMasterViewModel
{
    static IEventMasterViewModel CreateViewModel(IEventModelOperation operation, IErrorInformer informer)
    {
        return new EventMasterViewModel(operation, informer);
    }

    ICommand PlacedEvent { get; set; }

    ICommand PayedEvent { get; set; }

    ObservableCollection<IEventDetailViewModel> Events { get; set; }

    int StateId { get; set; }

    int UserId { get; set; }

    public ICommand RemoveEvent { get; set; }

    bool IsEventSelected { get; set; }

    Visibility IsEventDetailVisible { get; set; }

    IEventDetailViewModel SelectedDetailViewModel { get; set; }
}
