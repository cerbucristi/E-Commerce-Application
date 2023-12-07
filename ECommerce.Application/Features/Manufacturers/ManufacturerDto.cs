using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers
{
    public class ManufacturerDto
    {
        public Guid ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = default!;
    }
}
