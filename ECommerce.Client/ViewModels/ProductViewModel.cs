namespace ECommerce.Client.ViewModels;

public class ProductViewModel
{
    public bool IsCompleted()
    {
        return !(
            string.IsNullOrEmpty(this.Name) ||
            string.IsNullOrEmpty(this.Category) ||
            string.IsNullOrEmpty(this.ImageURL)
        );
    }
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public float Price { get; set; }
    public string ImageURL { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}