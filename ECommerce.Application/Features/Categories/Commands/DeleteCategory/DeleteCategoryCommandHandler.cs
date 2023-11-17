using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Events.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.CategoryId);
            if (!result.IsSuccess) 
            {
                return new DeleteCategoryCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { result.Error }
                };
            }
            return new DeleteCategoryCommandResponse
            {
                Success = true
            };
        }
    }
}
