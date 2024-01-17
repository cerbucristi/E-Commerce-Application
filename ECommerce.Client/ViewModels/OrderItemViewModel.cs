namespace ECommerce.Client.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public float GetTotal()
        {
            return Quantity * Price;
        }
    }
}
