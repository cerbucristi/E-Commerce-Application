using System;

namespace ECommerce.Client.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
