using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        // public string Description { get; set; }
        public decimal Price { get; set; }
        // public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        // public Guid ManufacturerId { get; set; }
        public string ImageURL { get; set; }

    }
}