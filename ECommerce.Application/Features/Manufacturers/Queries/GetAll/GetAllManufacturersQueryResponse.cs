using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Queries.GetAll
{
    public class GetAllManufacturersQueryResponse
    {
        public List<ManufacturerDto> Manufacturers { get; set; } = default!;
    }
}
