using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, UpdateManufacturerViewModel>
    {
        private readonly IManufacturerRepository repository;
        public UpdateManufacturerCommandHandler(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        
        public async Task<UpdateManufacturerViewModel> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateManufacturerCommandValidator(repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            if(!result.IsValid)
            {
                return new UpdateManufacturerViewModel
                {
                    Success = false,
                    ValidationsErrors = result.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var @manufacturer = await repository.FindByIdAsync(request.ManufacturerId);
            if (@manufacturer == null)
            {
                return new UpdateManufacturerViewModel
                {
                    Success = false,
                    ValidationsErrors = ["Manufacturer not found"]
                };
            };
            @manufacturer.Value.Update(request.ManufacturerName);
            await repository.UpdateAsync(@manufacturer.Value);
            return new UpdateManufacturerViewModel
            {
                Success = true,
                ManufacturerId = @manufacturer.Value.ManufacturerId,
                ManufacturerName = @manufacturer.Value.ManufacturerName
            };
        }
    }
}
