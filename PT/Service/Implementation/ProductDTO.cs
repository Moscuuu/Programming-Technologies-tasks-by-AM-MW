using Service.API;

namespace Service.Implementation;

internal class ProductDTO : IProductDTO
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string ProductDescription { get; set; }
    public float Price { get; set; }

    public ProductDTO(int id, string author, string productDescription, float price)
    {
        this.Id = id;
        this.Author = author;
        this.ProductDescription = productDescription;
        this.Price = price;
    }
}
