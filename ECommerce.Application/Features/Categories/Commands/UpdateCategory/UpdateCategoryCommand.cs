using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryViewModel>
    {
        public string CategoryName { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
