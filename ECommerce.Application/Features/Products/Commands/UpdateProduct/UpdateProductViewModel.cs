using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductViewModel : BaseResponse
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
