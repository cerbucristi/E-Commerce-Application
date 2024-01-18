namespace ECommerce.Client.ViewModels;

public class ProductViewModel
{
    public bool IsCompleted()
    {
        return !(
            string.IsNullOrEmpty(this.ProductName) ||
            string.IsNullOrEmpty(this.CategoryName) ||
            string.IsNullOrEmpty(this.ImageURL)
        );
    }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public string ImageURL { get; set; }
    public bool Wishlist { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}