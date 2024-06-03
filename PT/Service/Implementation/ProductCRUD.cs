using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class ProductCRUD : IProductCRUD
{
    private IDataRepository _repository;

    public ProductCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    private IProductDTO Map(IProduct product)
    {
        return new ProductDTO(product.id, product.productName, product.productDescription, product.price);
    }

    public async Task AddProduct(int id, string productName, string productDescription, float price)
    {
        await this._repository.AddProduct(id, productName, productDescription, price);
    }

    public async Task<IProductDTO> GetProduct(int id)
    {
        return this.Map(await this._repository.GetProduct(id));
    }

    public async Task UpdateProduct(int id, string productName, string productDescription, float price)
    {
        await this._repository.UpdateProduct(id, productName, productDescription, price);
    }

    public async Task DeleteProduct(int id)
    {
        await this._repository.DeleteProduct(id);
    }

    public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
    {
        Dictionary<int, IProductDTO> result = new Dictionary<int, IProductDTO>();

        foreach (IProduct product in (await this._repository.GetAllProducts()).Values)
        {
            result.Add(product.id, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCount()
    {
        return await this._repository.GetProductsCount();
    }
}
