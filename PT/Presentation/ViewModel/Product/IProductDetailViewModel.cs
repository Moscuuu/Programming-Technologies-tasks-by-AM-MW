using Presentation.Model.API;
using System.Windows.Input;

namespace Presentation.ViewModel;

public interface IProductDetailViewModel
{
    static IProductDetailViewModel CreateViewModel(int id, string name, string description, float price,
        IProductModelOperation model, IErrorInformer informer)
    {
        return new ProductDetailViewModel(id, name, description, price, model, informer);
    }

    ICommand UpdateProduct { get; set; }

    int Id { get; set; }

    string ProductName { get; set; }

    string Description { get; set; }

    float Price { get; set; }
}
