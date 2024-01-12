namespace ECommerce.Client.ViewModels
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ProductUrl { get; set; } = string.Empty;

        public float ProductPrice { get; set; }

    }
}
