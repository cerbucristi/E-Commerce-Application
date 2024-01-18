using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using MediatR;
using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Contracts;
using ECommerce.Application.Models;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMailService _mailService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, ICurrentUserService currentUserService, IMailService mailService )
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            _currentUserService = currentUserService;
            _mailService = mailService;
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

            var userId = Guid.Parse(_currentUserService.GetCurrentUserId());

            var order = Order.Create(userId, request.LastName, request.FirstName, request.PhoneNumber, request.Address, request.Payment, request.OrderItems);

            if (!order.IsSuccess)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { order.Error }
                };
            }

            foreach (var orderItem in request.OrderItems)
            {
                var product = await productRepository.FindByIdAsync(orderItem.ProductId);
                if (product == null)
                {
                    return new CreateOrderCommandResponse
                    {
                        Success = false,
                        ValidationsErrors = new List<string> { $"Product with ID {orderItem.ProductId} does not exist." }
                    };
                }

                var createdOrderItem = OrderItem.Create(orderItem.ProductId, orderItem.Quantity, orderItem.Price);
                if (!createdOrderItem.IsSuccess)
                {
                    return new CreateOrderCommandResponse
                    {
                        Success = false,
                        ValidationsErrors = new List<string> { createdOrderItem.Error }
                    };
                }

                order.Value.AddOrderItem(createdOrderItem.Value);
            }

            if (userId != order.Value.CustomerId)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { "Unauthorized access. The current user is not allowed to create an order for the provided customer ID." }
                };
            }

            try
            {
                await orderRepository.AddAsync(order.Value);

                //sending the confirmation mail
                MailData mail = new MailData();
                mail.EmailToId = _currentUserService.GetCurrentUserEmail();
                mail.EmailToName = request.LastName + " " + request.FirstName;
                mail.EmailSubject = "E Commerce Order Confirm";
                mail.EmailBody = "The order with id " + order.Value.OrderId + " was successfully placed";

                _mailService.SendMail(mail);

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
                        Payment = order.Value.Payment,
                        TotalPrice = order.Value.TotalPrice
                    }
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { $"An error occurred while processing the order: {ex.Message}" }
                };
            }
        }
    }
}
