namespace ECommerce.Client.ViewModels
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductImageURL { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
