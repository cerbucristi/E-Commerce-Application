using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommand : IRequest<CreateManufacturerCommandResponse>
    {
        public string ManufacturerName { get; set; } = default!;
    }
}
