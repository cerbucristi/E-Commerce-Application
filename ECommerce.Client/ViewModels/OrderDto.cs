using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels
{
    public class OrderDto
    {
        [JsonPropertyName("orderId")]
        public Guid OrderId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemDto> OrderItems { get; set; }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; }
    }
}
