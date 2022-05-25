using WK.Tech.Data;
using WK.Tech.Data.Repository;
using WK.Tech.Domain.Interfaces.Repositories;
using WK.Tech.Domain.Interfaces.Services;
using WK.Tech.Domain.Services;

namespace WK.Tech.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CatalogContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
