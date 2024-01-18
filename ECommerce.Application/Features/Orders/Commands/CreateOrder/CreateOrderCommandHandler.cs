using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using MediatR;
using ECommerce.Application.Contracts.Interfaces;
using System.Net;
using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Features.Wishlists.Commands.CreateWishlist;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        


        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }            

            var order = Order.Create(request.CustomerId, request.LastName, request.FirstName, request.PhoneNumber, request.Address, request.Payment,request.OrderItems);
            if (!order.IsSuccess)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { order.Error }
                };
            }
            await _orderRepository.AddAsync(order.Value);
            return new CreateOrderCommandResponse
            {
                Success = true,
                Order = new CreateOrderDto
                {
                    OrderId = order.Value.OrderId,
                    LastName = order.Value.LastName,
                    FirstName = order.Value.FirstName,
                    Address = order.Value.Address,
                    PhoneNumber = order.Value.PhoneNumber,
                    CustomerId = order.Value.CustomerId,
                    OrderDate = order.Value.OrderDate,
                    OrderStatus = order.Value.OrderStatus,
                    OrderItems = order.Value.OrderItems,
                    Payment = order.Value.Payment
                }                
            };
        }           
    }
}
