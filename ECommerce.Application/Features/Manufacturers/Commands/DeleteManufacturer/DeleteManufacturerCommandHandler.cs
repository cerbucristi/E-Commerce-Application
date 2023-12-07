using ECommerce.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, DeleteManufacturerCommandResponse>
    {
        public IManufacturerRepository repository;
        public DeleteManufacturerCommandHandler(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DeleteManufacturerCommandResponse> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.ManufacturerId);
            if(result.IsSuccess)
            {
                return new DeleteManufacturerCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { result.Error }
                };
            }
            return new DeleteManufacturerCommandResponse { Success = true };
        }
    }
}
