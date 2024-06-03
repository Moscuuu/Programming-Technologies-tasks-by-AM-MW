namespace DataLayer.API
{
    public interface IProduct
    {
        int id { get; set; }
        string productName { get; set; }
        string productDescription { get; set; }
        float price { get; set; }
    }

}
