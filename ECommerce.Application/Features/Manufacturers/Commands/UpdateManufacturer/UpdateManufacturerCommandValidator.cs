using ECommerce.Application.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
    {
        private readonly IManufacturerRepository repository;
        public UpdateManufacturerCommandValidator(IManufacturerRepository repository)
        {
            RuleFor(m => m.ManufacturerName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            this.repository = repository;
        }
    }
}
