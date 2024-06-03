namespace Presentation.Model.API;

public interface IProductModel
{
    int Id { get; set; }

    string ProductName { get; set; }

    string ProductDescription { get; set; }

    float Price { get; set; }
}
