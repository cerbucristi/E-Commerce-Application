using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommand : IRequest<UpdateManufacturerViewModel>
    {
        public string ManufacturerName { get; set; } = string.Empty;
        public Guid ManufacturerId { get; set; }
    }
}
