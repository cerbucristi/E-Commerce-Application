using ECommerce.Application.Persistence;
using ECommerce.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Queries.GetById
{
    internal class GetByIdManufacturerQueryHandler : IRequestHandler<GetByIdManufacturerQuery, ManufacturerDto>
    {
        private readonly IManufacturerRepository repository;
        public GetByIdManufacturerQueryHandler(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ManufacturerDto> Handle(GetByIdManufacturerQuery request, CancellationToken cancellationToken)
        {
            var manufacturer = await repository.FindByIdAsync(request.Id);
            if(manufacturer.IsSuccess)
            {
                return new ManufacturerDto
                {
                    ManufacturerId = manufacturer.Value.ManufacturerId,
                    ManufacturerName = manufacturer.Value.ManufacturerName,
                };
            }
            return new ManufacturerDto();
        }
    }
}
