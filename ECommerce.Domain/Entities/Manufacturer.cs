using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Manufacturer : AuditableEntity
    {
        public Manufacturer(string manufacturerName)
        {
            ManufacturerId = Guid.NewGuid();
            ManufacturerName = manufacturerName;
            Products = new List<Product>();
        }

        public Guid ManufacturerId { get; private set; }
        public string ManufacturerName { get; private set; } = string.Empty;
        public List<Product> Products { get; private set; }

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
            if (Products == null)
            {
                Products = new List<Product>();
            }
            Products.Add(product);
        }
        public void Update(string manufacturerName)
        {
            ManufacturerName = manufacturerName;
        }

    }
}
