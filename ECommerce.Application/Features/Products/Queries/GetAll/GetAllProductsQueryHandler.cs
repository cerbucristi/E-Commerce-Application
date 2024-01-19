using ECommerce.Application.Contracts.Interfaces;
using ECommerce.Application.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IWishlistRepository wishlistRepository;
        private readonly ICurrentUserService currentUserService;

        public GetAllProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IWishlistRepository wishlistRepository, ICurrentUserService currentUserService)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.wishlistRepository = wishlistRepository;
            this.currentUserService = currentUserService;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            GetAllProductsResponse response = new();
            var productsResult = await productRepository.GetAllAsync();
            var categoriesResult = await categoryRepository.GetAllAsync();
            

            if (productsResult.IsSuccess && categoriesResult.IsSuccess)
            {

                if (currentUserService.IsUserAuthorized())
                {
                    var userIdString = currentUserService.GetCurrentUserId();
                    Guid userId = Guid.Parse(userIdString);
                    var wishlistItems = await wishlistRepository.GetByUserIdAsync(userId);

                    response.Products = productsResult.Value.Select(p =>
                    {
                        var category = categoriesResult.Value.First(category =>
                            category.CategoryId.ToString() == p.CategoryId.ToString());

                        var productDto = new ProductDto
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            CategoryName = category.CategoryName,
                            CategoryId = category.CategoryId,
                            ImageURL = p.ImageURL,
                        };

                        productDto.Wishlist = wishlistItems.Value.Any(w => w.ProductId == p.ProductId);

                        return productDto;
                    }).ToList();
      
                } else
                {
                    response.Products = productsResult.Value.Select(p =>
                    {
                        var category = categoriesResult.Value.First(category =>
                            category.CategoryId.ToString() == p.CategoryId.ToString());

                        var productDto = new ProductDto
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            CategoryName = category.CategoryName,
                            CategoryId = category.CategoryId,
                            ImageURL = p.ImageURL,
                        };
                        return productDto;
                    }).ToList();
                }   
            }
            return response;
        }
    }
}
