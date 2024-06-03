using Presentation.Model.API;

namespace Presentation.Model.Implementation;

internal class ProductModel : IProductModel
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public float Price { get; set; }

    public ProductModel(int id, string name, string description, float price)
    {
        this.Id = id;
        this.ProductName = name;
        this.ProductDescription = description;
        this.Price = price;
    }
}
