using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

internal class ProductDetailViewModel : IViewModel, IProductDetailViewModel
{
    public ICommand UpdateProduct { get; set; }

    private readonly IProductModelOperation _modelOperation;

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

    private string _productName;

    public string ProductName
    {
        get => _productName;
        set
        {
            _productName = value;
            OnPropertyChanged(nameof(ProductName));
        }
    }

    private float _price;

    public float Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    private string _description;

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public ProductDetailViewModel(IProductModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IProductModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    public ProductDetailViewModel(int id, string name, string description, float price, IProductModelOperation? model = null, IErrorInformer? informer = null)
    {
        this.Id = id;
        this.ProductName = name;
        this.Description = description;
        this.Price = price;

        this.UpdateProduct = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = model ?? IProductModelOperation.CreateModelOperation();
        this._informer = informer ?? new PopupErrorInformer();
    }

    private void Update()
    {
        Task.Run(() =>
        {
            this._modelOperation.UpdateProduct(this.Id, this.ProductName, this.Description, this.Price);

            this._informer.InformSuccess("Product successfully updated!");
        });
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.ProductName) ||
            string.IsNullOrWhiteSpace(this.Description) ||
            string.IsNullOrWhiteSpace(this.Price.ToString()) ||
            string.IsNullOrWhiteSpace(this.Description.ToString()) ||
            this.Price == 0
        );
    }
}
