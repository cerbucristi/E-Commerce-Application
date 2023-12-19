using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Responses;

namespace ECommerce.Products.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() : base()
        {
        }

        public CreateProductDto Product { get; set; } = default!;
    }
}