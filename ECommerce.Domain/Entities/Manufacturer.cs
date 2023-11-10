using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities
{
    public class Manufacturer : AuditableEntity
    {
        private Manufacturer(string manufacturerName)
        {
            ManufacturerId = Guid.NewGuid();
            ManufacturerName = manufacturerName;
            Products = new List<Product>();
        }

        public Guid ManufacturerId { get; private set; }
        public string ManufacturerName { get; private set; }
        public List<Product> Products { get; private set; }
        public List<Event> Events { get; private set; }

        public static Result<Manufacturer> Create(string manufacturerName)
        {
            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                return Result<Manufacturer>.Failure("Manufacturer Name is required.");
            }
            return Result<Manufacturer>.Success(new Manufacturer(manufacturerName));
        }

        public void AttachProduct(Product product)
        {
            Products.Add(product);
        }

        public void AttachEvent(Event eventItem)
        {
            if (Events == null)
            {
                Events = new List<Event>();
            }
            Events.Add(eventItem);
        }
    }
}
