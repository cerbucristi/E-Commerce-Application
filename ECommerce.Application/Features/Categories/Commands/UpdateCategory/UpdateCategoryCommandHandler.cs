using ECommerce.Application.Features.Categories.Commands.UpdateCategory;
using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Events.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryViewModel>
    {
        private readonly ICategoryRepository repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateCategoryViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommandValidator(repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid){
                return new UpdateCategoryViewModel
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e=>e.ErrorMessage).ToList()
                };
            }
            var @category = await repository.FindByIdAsync(request.CategoryId);
            if (@category == null)
            {
                return new UpdateCategoryViewModel
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "Category not found" }
                };
            };

            @category.Value.Update(request.CategoryName);
            await repository.UpdateAsync(category.Value);
            return new UpdateCategoryViewModel
            {
                Success = true,
                CategoryId = @category.Value.CategoryId,
                CategoryName = @category.Value.CategoryName
            };
        }
    }
}
