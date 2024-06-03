using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EventMasterViewModel : IViewModel, IEventMasterViewModel
{
    public ICommand SwitchToUserMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand PlacedEvent { get; set; }

    public ICommand PayedEvent { get; set; }

    public ICommand RemoveEvent { get; set; }

    private readonly IEventModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<IEventDetailViewModel> _events;

    public ObservableCollection<IEventDetailViewModel> Events
    {
        get => _events;
        set
        {
            _events = value;
            OnPropertyChanged(nameof(Events));
        }
    }

    private int _stateId;

    public int StateId
    {
        get => _stateId;
        set
        {
            _stateId = value;
            OnPropertyChanged(nameof(StateId));
        }
    }

    private int _userId;

    public int UserId
    {
        get => _userId;
        set
        {
            _userId = value;
            OnPropertyChanged(nameof(UserId));
        }
    }

    private bool _isEventSelected;

    public bool IsEventSelected
    {
        get => _isEventSelected;
        set
        {
            this.IsEventDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isEventSelected = value;
            OnPropertyChanged(nameof(IsEventSelected));
        }
    }

    private Visibility _isEventDetailVisible;

    public Visibility IsEventDetailVisible
    {
        get => _isEventDetailVisible;
        set
        {
            _isEventDetailVisible = value;
            OnPropertyChanged(nameof(IsEventDetailVisible));
        }
    }

    private IEventDetailViewModel _selectedDetailViewModel;

    public IEventDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsEventSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public EventMasterViewModel(IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");

        this.PlacedEvent = new OnClickCommand(e => this.StorePlaceEvent(), c => this.CanPlaceEvent());
        this.PayedEvent = new OnClickCommand(e => this.StorePayEvent(), c => this.CanPayEvent());
        this.RemoveEvent = new OnClickCommand(e => this.DeleteEvent());

        this.Events = new ObservableCollection<IEventDetailViewModel>();

        this._modelOperation = IEventModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsEventSelected = false;

        Task.Run(this.LoadEvents);
    }

    private bool CanPlaceEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StateId.ToString()) ||
            string.IsNullOrWhiteSpace(this.UserId.ToString())
        );
    }

    private bool CanPayEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StateId.ToString()) ||
            string.IsNullOrWhiteSpace(this.UserId.ToString())
        );
    }

    private void StorePlaceEvent()
    {
        Task.Run(async () =>
        {
            try
            {
                int lastId = await this._modelOperation.GetEventsCount() + 1;

                await this._modelOperation.AddEvent(lastId, this.StateId, this.UserId, "PlacedEvent");

                this.LoadEvents();

                this._informer.InformSuccess("Event successfully created!");
            }
            catch (Exception e)
            {
                this._informer.InformError(e.Message);
            }
        });
    }

    private void StorePayEvent()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetEventsCount() + 1;

            await this._modelOperation.AddEvent(lastId, this.StateId, this.UserId, "PayedEvent");

            this.LoadEvents();

            this._informer.InformSuccess("Event successfully created!");
        });
    }

    private void DeleteEvent()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.DeleteEvent(this.SelectedDetailViewModel.Id);

            this.LoadEvents();

            this._informer.InformSuccess("Event successfully deleted!");
        });
    }

    private async void LoadEvents()
    {
        Dictionary<int, IEventModel> Events = (await this._modelOperation.GetAllEvents());

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._events.Clear();

            foreach (IEventModel e in Events.Values)
            {
                this._events.Add(new EventDetailViewModel(e.Id, e.StateId, e.UserId, e.Type));
            }
        });

        OnPropertyChanged(nameof(Events));
    }
}
