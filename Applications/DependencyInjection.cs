using Applications;
using Applications.Interfaces;
using Applications.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var zuniServices = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name.EndsWith("Service") && x.IsClass && !x.IsAbstract);
            foreach (var service in zuniServices)
            {
                var @interface = service.GetInterface($"I{service.Name}");
                services.AddScoped(@interface, service);
            }
            return services;
        }
    }
}
