using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels
{
    public class OrderUpdateViewModel
    {
        public Guid OrderId { get; set; }
        
        public string OrderStatus { get; set; }
    }
}
