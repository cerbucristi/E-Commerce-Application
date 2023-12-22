using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
        Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryViewModel categoryViewModel);
        Task<ApiResponse<CategoryDto>> DeleteCategoryAsync(CategoryViewModel categoryViewModel);


    }
}
