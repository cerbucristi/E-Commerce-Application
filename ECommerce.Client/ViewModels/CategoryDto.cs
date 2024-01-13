using System.Text.Json.Serialization;

namespace ECommerce.Client.ViewModels;

public class CategoryDto
{
    [JsonPropertyName("categoryId")]
    public Guid CategoryId { get; set; }
    
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;
}