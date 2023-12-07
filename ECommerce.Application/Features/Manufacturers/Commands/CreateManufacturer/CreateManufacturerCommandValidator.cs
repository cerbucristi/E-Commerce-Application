using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
    {
        public CreateManufacturerCommandValidator()
        {
            RuleFor(p => p.ManufacturerName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
