using ECommerce.Application.Persistence;
using ECommerce.Infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureRegistrationDI
    {
        public static IServiceCollection AddInfrastrutureToDI(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("ECommerceConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(ECommerceContext)
                        .Assembly.FullName)));

            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IManufacturerRepository,ManufacturerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();


            return services;
        }
    }
}
