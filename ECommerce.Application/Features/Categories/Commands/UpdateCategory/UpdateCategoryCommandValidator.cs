using ECommerce.Application.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository repository;
        public UpdateCategoryCommandValidator(ICategoryRepository repository)
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            this.repository = repository;

        }
    }
}
