using ECommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerViewModel : BaseResponse
    {
        public Guid ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
    }
}
