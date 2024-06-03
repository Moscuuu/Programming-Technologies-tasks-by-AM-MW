using Service.API;

namespace ServiceTest.FakeItems
{
    internal class FakeProductCRUD : IProductCRUD
    {
        private FakeDataRepository _dataRepository = new FakeDataRepository();

        public async Task AddProduct(int id, string productName, string productDescription, float price)
        {
            await _dataRepository.AddProduct(id, productName, productDescription, price);
        }

        public async Task DeleteProduct(int id)
        {
            await _dataRepository.DeleteProduct(id);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
        {
            return await _dataRepository.GetAllProducts();
        }

        public async Task<IProductDTO> GetProduct(int id)
        {
            return await _dataRepository.GetProduct(id);
        }

        public async Task<int> GetProductsCount()
        {
            return await _dataRepository.GetProductsCount();
        }

        public async Task UpdateProduct(int id, string productName, string productDescription, float price)
        {
            await _dataRepository.UpdateProduct(id, productName, productDescription, price);
        }
    }
}
