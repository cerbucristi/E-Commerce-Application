using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface IManufacturerDataService
    {
        Task<List<ManufacturerViewModel>> GetManufacturersAsync();

        Task<ApiResponse<ManufacturerDto>> CreateManufacturerAsync(ManufacturerViewModel manufacturerViewModel);
        Task<ApiResponse<ManufacturerDto>> UpdateManufacturerAsync(ManufacturerViewModel manufacturerViewModel);
        Task<ApiResponse<ManufacturerDto>> DeleteManufacturerAsync(ManufacturerViewModel manufacturerViewModel);
    }

}
