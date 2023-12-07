using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : AuditableEntity
    {
        private Product(string productName, decimal price, int stockQuantity, Guid categoryId)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public static Result<Product> Create(string productName, decimal price, int stockQuantity, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(productName) || price <= 0 || stockQuantity < 0)
            {
                return Result<Product>.Failure("Invalid product data.");
            }
            return Result<Product>.Success(new Product(productName, price, stockQuantity, categoryId));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddToCategory(Guid categoryId)
        {
            if(categoryId != Guid.Empty)
            {
                CategoryId = categoryId;
            }
        }
    }
}