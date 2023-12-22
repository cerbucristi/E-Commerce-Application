using ECommerce.Application.Features.Categories.Queries.GetAll;
using ECommerce.Application.Persistence;
using FluentAssertions;
using NSubstitute;

namespace ECommerce.Application.Tests.Queries
{
    public class GetAllCategoriesQueryHandlerTests : IDisposable
    {
        private ICategoryRepository _mockCategoryRepository;
        public GetAllCategoriesQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        }
        [Fact]
        public async Task GetAllCategoriesQueryHandler_Success()
        {
            var handler = new GetAllCategoriesQueryHandler(_mockCategoryRepository);
            var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);
            
            result.Should().NotBeNull();
            result.Categories.Should().NotBeNullOrEmpty();
            result.Categories.Count.Should().Be(3);
        }
        [Fact]
        public async Task GetAllCategoriesQueryHandler_Failure()
        {
            _mockCategoryRepository = Substitute.For<ICategoryRepository>();
            var handler = new GetAllCategoriesQueryHandler(_mockCategoryRepository);
            var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            result.Should().BeNull();
            /*result.Categories.Should().BeNullOrEmpty();*/
        }

        public void Dispose()
        {
            ResetMockCategoryRepository();
        }
        private void ResetMockCategoryRepository()
        {
            _mockCategoryRepository = Substitute.For<ICategoryRepository>();
        }
    }
}
