using Presentation.Model.API;
using System.Windows.Input;
namespace Presentation.ViewModel;

internal class UserDetailViewModel : IViewModel, IUserDetailViewModel
{
    public ICommand UpdateUser { get; set; }

    private readonly IUserModelOperation _modelOperation;

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

    private string _firstName;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    public UserDetailViewModel(IUserModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    public UserDetailViewModel(int id, string firstName, string lastName, IUserModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;

        this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateUser(this.Id, this.FirstName, this.LastName);

            this._informer.InformSuccess("User successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.FirstName) ||
            string.IsNullOrWhiteSpace(this.LastName)
        );
    }
}
