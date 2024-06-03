using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class ProductModelOperation : IProductModelOperation
{
    private IProductCRUD _productCRUD;

    public ProductModelOperation(IProductCRUD? productCrud = null)
    {
        this._productCRUD = productCrud ?? IProductCRUD.CreateProductCRUD();
    }

    private IProductModel Map(IProductDTO product)
    {
        return new ProductModel(product.Id, product.Author, product.ProductDescription, product.Price);
    }

    public async Task AddProduct(int id, string name, string description, float price)
    {
        await this._productCRUD.AddProduct(id, name, description, price);
    }

    public async Task<IProductModel> GetProduct(int id)
    {
        return this.Map(await this._productCRUD.GetProduct(id));
    }

    public async Task UpdateProduct(int id, string name, string description, float price)
    {
        await this._productCRUD.UpdateProduct(id, name, description, price);
    }

    public async Task DeleteProduct(int id)
    {
        await this._productCRUD.DeleteProduct(id);
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProducts()
    {
        Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

        foreach (IProductDTO product in (await this._productCRUD.GetAllProducts()).Values)
        {
            result.Add(product.Id, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCount()
    {
        return await this._productCRUD.GetProductsCount();
    }
}
