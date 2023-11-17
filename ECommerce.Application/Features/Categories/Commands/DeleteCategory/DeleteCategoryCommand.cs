using MediatR;

namespace ECommerce.Application.Features.Events.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
    }
}
