using Avaliacao1.JonStore.Repository.Interfaces;
using Avaliacao1.JonStore.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao1.JonStore.Repository
{
    public static class JonStoreRepositoryDependencyInjection
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
