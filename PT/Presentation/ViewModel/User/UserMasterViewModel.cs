using Presentation.Model.API;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class UserMasterViewModel : IViewModel, IUserMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand CreateUser { get; set; }

    public ICommand RemoveUser { get; set; }

    private readonly IUserModelOperation _modelOperation;

    private readonly IErrorInformer _informer;

    private ObservableCollection<IUserDetailViewModel> _users;

    public ObservableCollection<IUserDetailViewModel> Users
    {
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged(nameof(Users));
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

    private bool _isUserSelected;

    public bool IsUserSelected
    {
        get => _isUserSelected;
        set
        {
            this.IsUserDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isUserSelected = value;
            OnPropertyChanged(nameof(IsUserSelected));
        }
    }

    private Visibility _isUserDetailVisible;

    public Visibility IsUserDetailVisible
    {
        get => _isUserDetailVisible;
        set
        {
            _isUserDetailVisible = value;
            OnPropertyChanged(nameof(IsUserDetailVisible));
        }
    }

    private IUserDetailViewModel _selectedDetailViewModel;

    public IUserDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsUserSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public UserMasterViewModel(IUserModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.CreateUser = new OnClickCommand(e => this.StoreUser(), c => this.CanStoreUser());
        this.RemoveUser = new OnClickCommand(e => this.DeleteUser());

        this.Users = new ObservableCollection<IUserDetailViewModel>();

        this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();

        this.IsUserSelected = false;

        Task.Run(this.LoadUsers);
    }

    private bool CanStoreUser()
    {
        return !(
            string.IsNullOrWhiteSpace(this.FirstName) ||
            string.IsNullOrWhiteSpace(this.LastName)
        );
    }

    private void StoreUser()
    {
        Task.Run(async () =>
        {
            int lastId = await this._modelOperation.GetUsersCount() + 1;

            await this._modelOperation.AddUser(lastId, this.FirstName, this.LastName);

            this._informer.InformSuccess("User successfully created!");

            this.LoadUsers();
        });
    }

    private void DeleteUser()
    {
        Task.Run(async () =>
        {
            try
            {
                await this._modelOperation.DeleteUser(this.SelectedDetailViewModel.Id);

                this._informer.InformSuccess("User successfully deleted!");

                this.LoadUsers();
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting user! Remember to remove all associated events!");
            }
        });
    }

    private async void LoadUsers()
    {
        Dictionary<int, IUserModel> Users = await this._modelOperation.GetAllUsers();

        Application.Current.Dispatcher.Invoke(() =>
        {
            this._users.Clear();

            foreach (IUserModel u in Users.Values)
            {
                this._users.Add(new UserDetailViewModel(u.Id, u.FirstName, u.LastName));
            }
        });

        OnPropertyChanged(nameof(Users));
    }
}
