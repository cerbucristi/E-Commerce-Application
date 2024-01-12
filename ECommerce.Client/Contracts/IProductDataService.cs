using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetProductsAsync();
    }
}
