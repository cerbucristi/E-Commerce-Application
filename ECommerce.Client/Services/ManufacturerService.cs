using ECommerce.Client.Contracts;
using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerce.Client.Services
{
    public class ManufacturerDataService : IManufacturerDataService
    {
        private const string RequestUri = "api/v1/manufacturers";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public ManufacturerDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<ManufacturerDto>> CreateManufacturerAsync(ManufacturerViewModel manufacturerViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, manufacturerViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ManufacturerDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<ManufacturerViewModel>> GetManufacturersAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var manufacturers = JsonSerializer.Deserialize<List<ManufacturerViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return manufacturers!;
        }

        public async Task<ApiResponse<ManufacturerDto>> UpdateManufacturerAsync(ManufacturerViewModel manufacturer)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{manufacturer.ManufacturerId}", manufacturer);
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ManufacturerDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;

            return response!;
        }

        public async Task<ApiResponse<ManufacturerDto>> DeleteManufacturerAsync(ManufacturerViewModel manufacturer)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/{manufacturer.ManufacturerId}");
            result.EnsureSuccessStatusCode();

            if (result.IsSuccessStatusCode)
            {
                return new ApiResponse<ManufacturerDto>
                {
                    IsSuccess = true,
                    Message = "Manufacturer deleted successfully"
                };
            }
            else
            {
                return new ApiResponse<ManufacturerDto>
                {
                    IsSuccess = false,
                    Message = $"Failed to delete manufacturer. Status code: {result.StatusCode}",
                };
            }
        }
    }
}
