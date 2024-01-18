using ECommerce.Application.Features.Events.Commands.DeleteCategory;
using ECommerce.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderCommandResponse>
    {
        private readonly IOrderRepository repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.OrderId);
            if (!result.IsSuccess)
            {
                return new DeleteOrderCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { result.Error }
                };
            }
            return new DeleteOrderCommandResponse
            {
                Success = true
            };
        }
    }
}