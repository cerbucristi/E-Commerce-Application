using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ECommerce.Domain.Entities
{
    public class Order : AuditableEntity
    {
        private Order(Guid customerId, string lastName, string firstName, string phoneNumber, string address, string payment)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Address = address;
            OrderDate = DateTime.UtcNow;
            OrderStatus = "Pending";
            OrderItems =  new List<OrderItem>();
            Payment = payment;
        }

        public Guid OrderId { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderStatus { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public string Payment { get; private set; }


        public static Result<Order> Create(Guid customerId, string lastName, string firstName, string phoneNumber, string address, string payment, List<OrderItem> orderItems)
        {
            if (customerId == Guid.Empty)
            {
                return Result<Order>.Failure("Invalid customer id.");
            }
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
            {
                return Result<Order>.Failure("Last name and first name are required.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result<Order>.Failure("Phone number is required.");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                return Result<Order>.Failure("Address is required.");
            }

            return Result<Order>.Success(new Order(customerId, lastName, firstName, phoneNumber, address, payment));
        }

        public void Update(string orderStatus)
        {
            OrderStatus = orderStatus;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}