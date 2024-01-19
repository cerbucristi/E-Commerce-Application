using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Features.Orders.Queries.GetAll;
using ECommerce.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, List<OrderDto>>
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IOrderItemRepository _orderItemRepository;
        public readonly IProductRepository _productRepository;
        private readonly ICurrentUserService _currentUserService;
        public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }
        public async Task<List<OrderDto>> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {            
            GetAllOrdersResponse response = new();
            var ordersResult = await _orderRepository.GetAllAsync();
            var orderItemsResult = await _orderItemRepository.GetAllAsync();
            var userIdString = _currentUserService.GetCurrentUserId();
            Guid userId = Guid.Parse(userIdString);

            if (ordersResult.IsSuccess && orderItemsResult.IsSuccess)
            {
                response.Orders = ordersResult.Value.Where(o => o.CustomerId == userId).Select(o => new OrderDto
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
            return response.Orders;
        }
    }
}
