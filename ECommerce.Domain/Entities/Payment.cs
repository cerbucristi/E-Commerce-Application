using ECommerce.Domain.Common;
using System;

namespace ECommerce.Domain.Entities
{
    public class Payment : AuditableEntity
    {
        private Payment(Guid orderId, string paymentMethod, decimal paymentAmount)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            PaymentMethod = paymentMethod;
            PaymentAmount = paymentAmount;
            PaymentStatus = "Pending"; // You can use an enum or more detailed status if needed
        }

        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public string PaymentMethod { get; private set; }
        public decimal PaymentAmount { get; private set; }
        public string PaymentStatus { get; private set; }

        public static Result<Payment> Create(Guid orderId, string paymentMethod, decimal paymentAmount)
        {
            // You can add additional validation here if needed.
            return Result<Payment>.Success(new Payment(orderId, paymentMethod, paymentAmount));
        }
    }
}
