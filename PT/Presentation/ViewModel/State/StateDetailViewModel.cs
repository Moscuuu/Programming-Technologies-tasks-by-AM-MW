using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class StateDetailViewModel : IViewModel, IStateDetailViewModel
{
    public ICommand UpdateState { get; set; }

    private readonly IStateModelOperation _modelOperation;

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

    private int _productId;

    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged(nameof(ProductId));
        }
    }

    private bool _available;

    public bool Available
    {
        get => _available;
        set
        {
            _available = value;
            OnPropertyChanged(nameof(Available));
        }
    }

    public StateDetailViewModel(IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IStateModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    public StateDetailViewModel(int id, int productId, bool available, IStateModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.Id = id;
        this.ProductId = productId;
        this.Available = available;

        this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IStateModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateState(this.Id, this.ProductId, this.Available);

            this._informer.InformSuccess("State successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Available.ToString())
        );
    }
}
