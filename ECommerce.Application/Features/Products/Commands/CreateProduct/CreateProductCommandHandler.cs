using ECommerce.Application.Persistence;
using ECommerce.Domain.Entities;
using ECommerce.Products.Features.Product.Commands.CreateProduct;
using ECommerce.Products.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository repository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly ICategoryRepository categoryRepository;

        public CreateProductCommandHandler(IProductRepository repository, IManufacturerRepository manufacturerRepository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.manufacturerRepository = manufacturerRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateProductCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            } 
            //verificam daca exista manufacturerId si categoryid
            var category = await categoryRepository.FindByIdAsync(request.CategoryId);
            if (!category.IsSuccess)
            {
                return new CreateProductCommandResponse
                {
                    Success = false
                };
            }
            var manufacturer = await manufacturerRepository.FindByIdAsync(request.ManufacturerId);
            if (!manufacturer.IsSuccess)
            {
                return new CreateProductCommandResponse
                {
                    Success = false
                };
            }
          
            var product = Product.Create(request.ProductName,request.Description, request.Price,request.StockQuantity,request.CategoryId, request.ManufacturerId);
            if (!product.IsSuccess)
            {
                return new CreateProductCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { product.Error }
                };
            }

            await repository.AddAsync(product.Value);

            return new CreateProductCommandResponse
            {
                Success = true,
                Product = new CreateProductDto
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    Description = product.Value.Description,
                    Price = product.Value.Price,
                    StockQuantity = product.Value.StockQuantity,        
                    CategoryId = product.Value.CategoryId,
                    ManufacturerId = product.Value.ManufacturerId
                              
                }
            };
        }
    }
}
