using ECommerce.Client.Contracts;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class WishlistDataService : IWishlistDataService
{
    private const string RequestUri = "api/v1/wishlist";
    private readonly HttpClient httpClient;
    private readonly ITokenService tokenService;

    public WishlistDataService(HttpClient httpClient, ITokenService tokenService)
    {
        this.httpClient = httpClient;
        this.tokenService = tokenService;
    }

    public async Task<List<Guid>> GetWishlistAsync()
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var wishlist = JsonSerializer.Deserialize<List<Guid>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return wishlist ?? new List<Guid>();
        }
        catch (Exception)
        {
            return new List<Guid>();
        }
    }

    public async Task<bool> AddToWishlistAsync(Guid productId)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var requestObject = new { ProductId = productId };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestObject), Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync(RequestUri, jsonContent);

            result.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public async Task<bool> RemoveFromWishlistAsync(Guid productId)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/{productId}");
            result.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
