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
        // !!!!!!!!!!!!!! MAKE SURE THIS IS THE RIGHT ENDPOINT !!!!!!!!!! //
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
            // var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            // result.EnsureSuccessStatusCode();
            // var content = await result.Content.ReadAsStringAsync();
            // if (!result.IsSuccessStatusCode)
            // {
            //     throw new ApplicationException(content);
            // }
            // var categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            // return categories!;
            var products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Category = "Air purifying", Name = "Birdnest Japanese", Price = 84.90f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-8-400x600.jpg"
                },
                new ProductViewModel
                {
                    Category = "Indoor Plants", Name = "Hoya Obovatum", Price = 63.00f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-5-400x600.jpg"
                },
                new ProductViewModel
                {
                    Category = "Air purifying", Name = "Monstera Deliciosa", Price = 224.90f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-14-400x600.jpg"
                },
                new ProductViewModel
                {
                    Category = "Herb seeds", Name = "Zz Plants", Price = 124.90f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-8-400x600.jpg"
                },
                new ProductViewModel
                {
                    Category = "Ceramic pots", Name = "Bird of Paradise", Price = 249.90f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-4-400x600.jpg"
                },
                new ProductViewModel
                {
                    Category = "Herb seeds", Name = "Calathea Beauty Star", Price = 84.90f,
                    ImageURL =
                        "https://websitedemos.net/plant-shop-02/wp-content/uploads/sites/931/2021/08/plants-ecommerce-product-featured-img-7-400x600.jpg"
                }
            };

            return products;
        }
    }
}
