namespace ECommerce.Application.Features.Categories
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}