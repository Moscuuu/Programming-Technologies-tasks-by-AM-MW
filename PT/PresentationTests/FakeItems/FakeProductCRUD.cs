using Presentation.Model.API;

namespace PresentationTests.FakeItems
{
    internal class FakeProductCRUD : IProductModelOperation
    {
        private readonly FakeDataRepository _repository = new FakeDataRepository();

        public FakeProductCRUD()
        {
        }

        public async Task AddProduct(int id, string productName, string productDescription, float price)
        {
            await this._repository.AddProduct(id, productName, productDescription, price);
        }

        public async Task<IProductModel> GetProduct(int id)
        {
            return await this._repository.GetProduct(id);
        }

        public async Task UpdateProduct(int id, string productName, string productDescription, float price)
        {
            await this._repository.UpdateProduct(id, productName, productDescription, price);
        }

        public async Task DeleteProduct(int id)
        {
            await this._repository.DeleteProduct(id);
        }

        public async Task<Dictionary<int, IProductModel>> GetAllProducts()
        {
            Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

            foreach (IProductModel product in (await this._repository.GetAllProducts()).Values)
            {
                result.Add(product.Id, (IProductModel)product);
            }

            return result;
        }

        public async Task<int> GetProductsCount()
        {
            return await this._repository.GetProductsCount();
        }
    }
}
