using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels
{
    public class ProductDto
    {
        [JsonPropertyNameAttribute("productId")]
        public Guid ProductId { get; set; }
        
        [JsonPropertyNameAttribute("productName")]
        public string ProductName { get; set; } = string.Empty;
        
        public string ProductDescription { get; set; } = string.Empty;

        [JsonPropertyNameAttribute("imageURL")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyNameAttribute("price")]
        public float Price { get; set; }

    }
}
