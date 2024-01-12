﻿using ECommerce.Client.Contracts;
using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerce.Client.Services
{
    public class ProductDataService : IProductDataService
    {
        private const string RequestUri = "api/v1/products";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public ProductDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
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
            var products = JsonSerializer.Deserialize<List<ProductViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return products;
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, productViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(ProductViewModel product)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{product.ProductId}", product);
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;

            return response!;
        }

        public async Task<ApiResponse<ProductDto>> DeleteProductAsync(ProductViewModel product)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/{product.ProductId}");
            result.EnsureSuccessStatusCode();

            if (result.IsSuccessStatusCode)
            {
                return new ApiResponse<ProductDto>
                {
                    IsSuccess = true,
                    Message = "Product deleted successfully"
                };
            }
            else
            {
                return new ApiResponse<ProductDto>
                {
                    IsSuccess = false,
                    Message = $"Failed to delete product. Status code: {result.StatusCode}",
                };
            }
        }
    }
}
