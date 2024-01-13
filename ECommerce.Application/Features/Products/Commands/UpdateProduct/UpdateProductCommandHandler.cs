using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Persistence;
using ECommerce.Products.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductViewModel>
    {
        private readonly IProductRepository repository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly ICategoryRepository categoryRepository;

        public UpdateProductCommandHandler(IProductRepository repository, IManufacturerRepository manufacturerRepository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.manufacturerRepository = manufacturerRepository;   
            this.categoryRepository = categoryRepository;   
    }

        public async Task<UpdateProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator(repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid){
                return new UpdateProductViewModel
                {
                    Success = false,
                    ValidationsErrors = validatorResult.Errors.Select(e=>e.ErrorMessage).ToList()
                };
            }
            var @product = await repository.FindByIdAsync(request.ProductId);
            if (@product == null)
            {
                return new UpdateProductViewModel
                {
                    Success = false,
                    ValidationsErrors = ["Product not found"]
                };
            };
            var category = await categoryRepository.FindByIdAsync(request.CategoryId);
            if (!category.IsSuccess)
            {
                return new UpdateProductViewModel
                {
                    Success = false
                };
            }
            // var manufacturer = await manufacturerRepository.FindByIdAsync(request.ManufacturerId);
            // if (!manufacturer.IsSuccess)
            // {
            //     return new UpdateProductViewModel
            //     {
            //         Success = false
            //     };
            // }
// var manufacturer = await manufacturerRepository.FindByIdAsync(request.ManufacturerId);
            // if (!manufacturer.IsSuccess)
            // {
            //     return new UpdateProductViewModel
            //     {
            //         Success = false
            //     };
            // }
            @product.Value.Update(request.ProductName,request.Price,request.CategoryId,request.ImageURL);
            await repository.UpdateAsync(@product.Value);
            return new UpdateProductViewModel
            {
                Success = true,
                ProductId = @product.Value.ProductId,
                ProductName = @product.Value.ProductName,
                // Description = @product.Value.Description,
                Price = @product.Value.Price,
                // StockQuantity = @product.Value.StockQuantity,
                CategoryId = @product.Value.CategoryId,
                // ManufacturerId = @product.Value.ManufacturerId

            };
        }
    }
}
