using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.Client.Contracts;
using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Services
{
    public class OrderService : IOrderService
    {
        private const string RequestUri = "api/v1/orders";
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public OrderService(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<ApiResponse<OrderDto>> PlaceOrder(OrderViewModel order)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenService.GetTokenAsync());

                var response = await _httpClient.PostAsJsonAsync(RequestUri, order);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadFromJsonAsync<OrderDto>();
                return new ApiResponse<OrderDto> { Data = responseData, IsSuccess = true };
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log or throw)
                return new ApiResponse<OrderDto> { IsSuccess = false, Message = ex.Message };
            }
        }


        public async Task<IEnumerable<OrderViewModel>> GetOrders()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<OrderViewModel>>(RequestUri);
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log or throw)
                return null;
            }
        }

        public async Task<OrderViewModel> GetOrderById(Guid orderId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<OrderViewModel>($"{RequestUri}/{orderId}");
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log or throw)
                return null;
            }
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _tokenService.GetTokenAsync());

                var response = await _httpClient.DeleteAsync($"{RequestUri}/{orderId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log or throw)
                return false;
            }
        }

        // Add other methods as needed
    }
}
