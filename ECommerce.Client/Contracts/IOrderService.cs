using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Client.Services.Responses;
using ECommerce.Client.ViewModels;

namespace ECommerce.Client.Contracts
{
    public interface IOrderService
    {
        Task<ApiResponse<OrderDto>> PlaceOrder(OrderViewModel order);
        Task<List<OrderViewModel>> GetOrders();
        Task<OrderViewModel> GetOrderById(Guid orderId);
        Task<ApiResponse<OrderDto>> UpdateOrderAsync(OrderViewModel order, string status);
        Task<List<OrderViewModel>> GetOrdersByCustomerId();


    }
}
