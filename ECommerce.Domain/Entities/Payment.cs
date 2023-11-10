using ECommerce.Domain.Common;

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
            PaymentStatus = "Pending"; //we ll add some enum
        }

        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public string PaymentMethod { get; private set; }
        public decimal PaymentAmount { get; private set; }
        public string PaymentStatus { get; private set; }

        public static Result<Payment> Create(Guid orderId, string paymentMethod, decimal paymentAmount)
        {
            return Result<Payment>.Success(new Payment(orderId, paymentMethod, paymentAmount));
        }
    }
}
