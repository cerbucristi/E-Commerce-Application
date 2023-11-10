using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities
{
    public class Order : AuditableEntity
    {
        private Order(Guid customerId)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            OrderStatus = "Pending"; // You can use an enum or more detailed status if needed
            OrderItems = new List<OrderItem>();
        }

        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderStatus { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public List<Payment> Payments { get; private set; }

        public static Result<Order> Create(Guid customerId)
        {
            // You can add additional validation here if needed.
            return Result<Order>.Success(new Order(customerId));
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }
    }
}
