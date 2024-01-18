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
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, OrderDto>
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
        public async Task<OrderDto> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.orderId);
            if(order.IsSuccess)
            {
                return new OrderDto
                {
                    LastName = order.Value.LastName,
                    FirstName = order.Value.FirstName,
                    Address = order.Value.Address,
                    PhoneNumber = order.Value.PhoneNumber,
                    OrderDate = order.Value.OrderDate,
                    OrderStatus = order.Value.OrderStatus,
                    Payment = order.Value.Payment,
                    OrderItems = order.Value.OrderItems,
                    OrderId = order.Value.OrderId,
                    CustomerId = order.Value.CustomerId
                };
            }
            return new OrderDto();
            
        }
    }
}
