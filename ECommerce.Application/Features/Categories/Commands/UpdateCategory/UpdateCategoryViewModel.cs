using ECommerce.Application.Responses;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryViewModel : BaseResponse
    {
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
