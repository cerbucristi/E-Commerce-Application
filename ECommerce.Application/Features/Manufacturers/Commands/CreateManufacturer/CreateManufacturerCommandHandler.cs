using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, CreateManufacturerCommandResponse>
    {
        private readonly IManufacturerRepository ManufacturerRepository;

        public CreateManufacturerCommandHandler(IManufacturerRepository repository)
        {
            this.ManufacturerRepository = repository;
        }

        public async Task<CreateManufacturerCommandResponse> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateManufacturerCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateManufacturerCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var manufacturer = Manufacturer.Create(request.ManufacturerName);
            if (!manufacturer.IsSuccess)
            {
                return new CreateManufacturerCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { manufacturer.Error }
                };
            }

            await ManufacturerRepository.AddAsync(manufacturer.Value);

            return new CreateManufacturerCommandResponse
            {
                Success = true,
                Manufacturer = new CreateManufacturerDto
                {
                    ManufacturerId = manufacturer.Value.ManufacturerId,
                    ManufacturerName = manufacturer.Value.ManufacturerName,
                }
            };
        }
    }
}
