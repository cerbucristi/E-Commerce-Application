using ECommerce.Application.Features.Categories.Commands.UpdateCategory;
using ECommerce.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderViewModel>
    {
        private readonly IOrderRepository repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateOrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderCommandValidator(repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
            {
                return new UpdateOrderViewModel
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var @order = await repository.FindByIdAsync(request.OrderId);
            if (@order == null)
            {
                return new UpdateOrderViewModel
                {
                    Success = false,
                    ValidationsErrors = ["Order not found"]
                };
            };

            @order.Value.Update(request.OrderStatus);
            await repository.UpdateAsync(@order.Value);
            return new UpdateOrderViewModel
            {
                Success = true,
                OrderId = @order.Value.OrderId,
                OrderStatus = @order.Value.OrderStatus
            };
        }
    }
}
