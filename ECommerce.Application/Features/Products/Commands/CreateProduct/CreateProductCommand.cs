using ECommerce.Domain.Entities;
using ECommerce.Products.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; }
        // public string Description { get; set; }
        public decimal Price { get; set; }
        // public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        // public Guid ManufacturerId { get; set; }
        public string ImageURL { get; set; }
    }
}
