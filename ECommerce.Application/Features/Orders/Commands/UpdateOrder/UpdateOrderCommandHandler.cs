using ECommerce.Application.Contracts;
using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Models;
using ECommerce.Application.Persistence;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderViewModel>
    {
        private readonly IOrderRepository repository;
        private readonly IMailService _mailService;
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderCommandHandler(IOrderRepository repository, IMailService _mailService, ICurrentUserService _currentUserService)
        {
            this.repository = repository;
            this._mailService = _mailService;
            this._currentUserService = _currentUserService;
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

            //sending the confirmation mail
            MailData mail = new MailData();
            mail.EmailToId = _currentUserService.GetCurrentUserEmail();
            mail.EmailToName = _currentUserService.GetCurrentUserEmail();
            mail.EmailSubject = "E Commerce Order Status Updated";
            mail.EmailBody = "The status for the order with id " + order.Value.OrderId + " was changed to " + request.OrderStatus;

            _mailService.SendMail(mail);

            return new UpdateOrderViewModel
            {
                Success = true,
                OrderId = @order.Value.OrderId,
                OrderStatus = @order.Value.OrderStatus
            };
        }
    }
}
