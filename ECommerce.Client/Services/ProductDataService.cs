using ECommerce.Client.Contracts;
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
            // return categories!;
            // var products = new List<ProductViewModel>
            // {
            //     new ProductViewModel
            //     {
            //         ProductId = Guid.NewGuid(),
            //         Category = "Air purifying", ProductName = "Birdnest Japanese", Price = 84.90f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-8-400x600.jpg"
            //     },
            //     new ProductViewModel
            //     {
            //         ProductId = Guid.NewGuid(),
            //
            //         Category = "Indoor Plants", ProductName = "Hoya Obovatum", Price = 63.00f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-5-400x600.jpg"
            //     },
            //     new ProductViewModel
            //     {
            //         ProductId = Guid.NewGuid(),
            //
            //         Category = "Air purifying", ProductName = "Monstera Deliciosa", Price = 224.90f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-14-400x600.jpg"
            //     },
            //     new ProductViewModel
            //     {                    
            //         ProductId = Guid.NewGuid(),
            //
            //         Category = "Herb seeds", ProductName = "Zz Plants", Price = 124.90f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-8-400x600.jpg"
            //     },
            //     new ProductViewModel
            //     {   
            //         ProductId = Guid.NewGuid(),
            //
            //         Category = "Ceramic pots", ProductName = "Bird of Paradise", Price = 249.90f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-4-400x600.jpg"
            //     },
            //     new ProductViewModel
            //     {                    
            //         ProductId = Guid.NewGuid(),
            //
            //         Category = "Herb seeds", ProductName = "Calathea Beauty Star", Price = 84.90f,
            //         ImageURL =
            //             "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-7-400x600.jpg"
            //     }
            // };

            return products!;
        }
        
        public async Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, productViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ProductDto>();
            return new ApiResponse<ProductDto>() { Data = response, IsSuccess = result.IsSuccessStatusCode};
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(ProductViewModel product)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{product.ProductId}", product);
            result.EnsureSuccessStatusCode();
            
            var response = await result.Content.ReadFromJsonAsync<ProductDto>();
            return new ApiResponse<ProductDto>() { Data = response, IsSuccess = result.IsSuccessStatusCode};
        }

        public async Task<ApiResponse<ProductDto>> DeleteProductAsync(Guid id)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/{id.ToString()}");
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