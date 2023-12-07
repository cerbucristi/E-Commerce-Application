using ECommerce.Application.Responses;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse
    {
        public UpdateCategoryCommandResponse() : base()
        {
        }

        public UpdateCategoryViewModel Category { get; set; } = default!;
    }
}