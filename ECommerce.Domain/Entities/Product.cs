using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities
{
    public class Product : AuditableEntity
    {
        private Product(string productName, decimal price, int stockQuantity)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
            Categories = new List<Category>();
        }

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Event> Events { get; private set; }

        public static Result<Product> Create(string productName, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(productName) || price <= 0 || stockQuantity < 0)
            {
                return Result<Product>.Failure("Invalid product data.");
            }
            return Result<Product>.Success(new Product(productName, price, stockQuantity));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddToCategory(Category category)
        {
            Categories.Add(category);
            category.AttachProduct(this);
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