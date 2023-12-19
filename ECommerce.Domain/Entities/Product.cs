using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : AuditableEntity
    {
        private Product(string productName, string description, decimal price, int stockQuantity, Guid categoryId, Guid manufacturerId)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            ManufacturerId = manufacturerId;
        }

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid ManufacturerId { get; private set; }
        public Category Category { get; private set; }
        public Manufacturer Manufacturer { get; private set; }

        public void AddToCategory(Category category)
        {
            if (category != null)
            {
                Category = category;
                CategoryId = category.CategoryId;

                category.Products.Add(this);
            }
        }
        public void AddToManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer != null)
            {
                Manufacturer = manufacturer;
                ManufacturerId = manufacturer.ManufacturerId;

                manufacturer.Products.Add(this);
            }
        }

        public static Result<Product> Create(string productName,string description, decimal price, int stockQuantity, Guid categoryId, Guid manufacturerId)
        {
            if (string.IsNullOrWhiteSpace(productName) || price <= 0 || stockQuantity < 0)
            {
                return Result<Product>.Failure("Invalid product data.");
            }
            return Result<Product>.Success(new Product(productName, description, price, stockQuantity, categoryId, manufacturerId));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

       /* public void AddToCategory(Guid categoryId)
        {
            if(categoryId != Guid.Empty)
            {
                CategoryId = categoryId;
            }
        }
        public void AddToManufacturer(Guid manufacturerId)
        {
            if (manufacturerId != Guid.Empty)
            {
                ManufacturerId = manufacturerId;
            }
        } */
        public void Update(string productName, string description, decimal price, int stockQuantity, Guid categoryId, Guid manufacturerId)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            ManufacturerId = manufacturerId;
        }
    }
}