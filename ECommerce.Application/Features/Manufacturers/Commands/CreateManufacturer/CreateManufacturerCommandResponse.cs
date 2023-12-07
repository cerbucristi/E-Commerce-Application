using ECommerce.Application.Responses;

namespace ECommerce.Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandResponse : BaseResponse
    {
        public CreateManufacturerCommandResponse() : base()
        {

        }
        public CreateManufacturerDto Manufacturer { get; set; } = default!;
    }
}
