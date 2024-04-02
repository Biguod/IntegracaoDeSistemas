using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Avaliacao1.JonStore.Domain.Extensions;

namespace Avaliacao1.JonStore.Service
{
    public static class JonStoreServiceDependencyInjection
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.ScanDependencyInjection(Assembly.GetExecutingAssembly(), "Service");
        }
    }
}
