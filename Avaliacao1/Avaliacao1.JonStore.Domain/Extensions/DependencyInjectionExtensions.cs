using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Avaliacao1.JonStore.Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void ScanDependencyInjection(this IServiceCollection services, Assembly projectAssembly, string classesEndWith)
        {
            var types = projectAssembly.GetTypes().Where(w => w.GetInterfaces().Any(a => a.Name.EndsWith(classesEndWith)));

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var inter in interfaces)
                    services.AddScoped(inter, type);
            }
        }
    }
}
