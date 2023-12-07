using MediatR;

namespace ECommerce.Application.Features.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommand : IRequest<DeleteManufacturerCommandResponse>
    {
        public Guid ManufacturerId { get; set; }
    }
}
