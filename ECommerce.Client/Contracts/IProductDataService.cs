using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel);
        Task<ApiResponse<ProductDto>> UpdateProductAsync(ProductViewModel productViewModel);
        Task<ApiResponse<ProductDto>> DeleteProductAsync(Guid id);
    }
}
