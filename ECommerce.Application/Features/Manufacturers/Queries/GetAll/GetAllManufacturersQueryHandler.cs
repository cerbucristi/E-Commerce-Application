using ECommerce.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Queries.GetAll
{
    public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, GetAllManufacturersQueryResponse>
    {
        private readonly IManufacturerRepository repository;
        public GetAllManufacturersQueryHandler(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetAllManufacturersQueryResponse> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            GetAllManufacturersQueryResponse response = new();
            var result = await repository.GetAllAsync();
            if (result.IsSuccess)
            {
                response.Manufacturers = result.Value.Select(m=>new ManufacturerDto
                {
                    ManufacturerId = m.ManufacturerId,
                    ManufacturerName = m.ManufacturerName,
                }).ToList();
            }
            return response;
        }
    }
}
