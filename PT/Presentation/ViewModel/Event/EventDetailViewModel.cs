using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class EventDetailViewModel : IViewModel, IEventDetailViewModel
{
    public ICommand UpdateEvent { get; set; }

    private readonly IEventModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private int _id;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
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

    private DateTime _eventDate;

    public DateTime EventDate
    {
        get => _eventDate;
        set
        {
            _eventDate = value;
            OnPropertyChanged(nameof(EventDate));
        }
    }

    private string _type;

    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    public EventDetailViewModel(IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IEventModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    public EventDetailViewModel(int id, int stateId, int userId, string type, IEventModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IEventModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.Id = id;
        this.StateId = stateId;
        this.UserId = userId;
        this.EventDate = DateTime.Now;
        this.Type = type;
    }

    private void Update()
    {
        Task.Run(async () =>
        {
            await this._modelOperation.UpdateEvent(this.Id, this.StateId, this.UserId, this.Type);

            this._informer.InformSuccess("Event successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.EventDate.ToString())
        );
    }
}
