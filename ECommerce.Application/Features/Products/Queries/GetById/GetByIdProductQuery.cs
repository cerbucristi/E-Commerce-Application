using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetById
{
    public record GetByIdProductQuery(Guid Id) : IRequest<ProductDto>; 
}
