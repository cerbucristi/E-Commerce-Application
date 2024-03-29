﻿using ECommerce.Client.Contracts;
using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerce.Client.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private const string RequestUri = "api/v1/categories";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public CategoryDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, categoryViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<CategoryDto>();
            // response!.IsSuccess = result.IsSuccessStatusCode;
            return new ApiResponse<CategoryDto>(){ IsSuccess = result.IsSuccessStatusCode, Data = response};
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
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
            var categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return categories!;
        }
        public async Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryViewModel category)
        {


            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{category.CategoryId}", category);
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<ApiResponse<CategoryDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;

            return response!;
        }
        public async Task<ApiResponse<CategoryDto>> DeleteCategoryAsync(CategoryViewModel category)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/{category.CategoryId}");
            result.EnsureSuccessStatusCode();

            if (result.IsSuccessStatusCode)
            {
                return new ApiResponse<CategoryDto>
                {
                    IsSuccess = true,
                    Message = "Category deleted successfully"
                };
            }
            else
            {
                return new ApiResponse<CategoryDto>
                {
                    IsSuccess = false,
                    Message = $"Failed to delete category. Status code: {result.StatusCode}",
                };
            }
        }


    }
}
