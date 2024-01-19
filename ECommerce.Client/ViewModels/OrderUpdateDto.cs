using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels
{
    public class OrderUpdateDto
    {
        [JsonPropertyName("orderId")]
        public Guid OrderId { get; set; }

        [JsonPropertyName("orderStatus")]
        public string OrderStatus { get; set; }
    }
}
