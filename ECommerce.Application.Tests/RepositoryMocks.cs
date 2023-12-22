using ECommerce.Application.Persistence;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using NSubstitute;

namespace ECommerce.Application.Tests
{
    public class RepositoryMocks
    {
        public static ICategoryRepository GetCategoryRepository()
        {
            var Categories = new List<Category>
            {
                Category.Create("Sport").Value,
                Category.Create("Electronics").Value,
                Category.Create("Music").Value,
            };
            var mockCategoryRepository = Substitute.For<ICategoryRepository>();
            mockCategoryRepository.GetAllAsync().Returns(Result<IReadOnlyList<Category>>.Success(Categories));
            return mockCategoryRepository;
        }
    }
}