using MediatR;

namespace ECommerce.Application.Features.Manufacturers.Queries.GetById
{
    public record GetByIdManufacturerQuery(Guid Id):IRequest<ManufacturerDto>;

}
