using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, GetAllOrdersResponse>
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IOrderItemRepository _orderItemRepository;
        private readonly ICurrentUserService _currentUserService;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository,IOrderItemRepository orderItemRepository,ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            
            _currentUserService = currentUserService;
        }
        public async Task<GetAllOrdersResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            GetAllOrdersResponse response = new();
            var ordersResult = await _orderRepository.GetAllAsync();
            var orderItemsResult = await _orderItemRepository.GetAllAsync();
            var userIdString = _currentUserService.GetCurrentUserId();

            Guid userId = Guid.Parse(userIdString);
            if(ordersResult.IsSuccess && orderItemsResult.IsSuccess)
            {            
                response.Orders = ordersResult.Value.Select(o=>new OrderDto
                {
                    OrderId = o.OrderId,
                    LastName = o.LastName,
                    FirstName = o.FirstName,
                    Address = o.Address,
                    PhoneNumber = o.PhoneNumber,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    OrderStatus = o.OrderStatus,
                    Payment = o.Payment,
                    OrderItems = o.OrderItems,
                    TotalPrice = o.TotalPrice
                }).ToList();
            }
           
            return response;
        }
    }
}
