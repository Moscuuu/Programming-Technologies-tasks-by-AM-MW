using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IProductModelOperation
{
    static IProductModelOperation CreateModelOperation(IProductCRUD? productCrud = null)
    {
        return new ProductModelOperation(productCrud ?? IProductCRUD.CreateProductCRUD());
    }

    Task AddProduct(int id, string name, string description, float price);

    Task<IProductModel> GetProduct(int id);

    Task UpdateProduct(int id, string name, string description, float price);

    Task DeleteProduct(int id);

    Task<Dictionary<int, IProductModel>> GetAllProducts();

    Task<int> GetProductsCount();
}
