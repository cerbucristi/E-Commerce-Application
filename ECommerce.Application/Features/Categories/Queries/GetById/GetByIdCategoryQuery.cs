using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetById
{
    public record GetByIdCategoryQuery(Guid Id) : IRequest<CategoryDto>; 
}
