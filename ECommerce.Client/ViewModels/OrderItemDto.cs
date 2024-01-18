using System;
using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels
{
    public class OrderItemDto
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        // Additional properties as needed
    }
}
