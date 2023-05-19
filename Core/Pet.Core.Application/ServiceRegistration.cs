using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pet.Core.Application_
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var assembly = Assembly.GetExecutingAssembly()
                          .ExportedTypes
                          .Where(consumer => consumer.FullName != null && consumer.FullName.Contains("Handler") && consumer.IsClass)
                          .ToArray();
            services.AddMediatR(assembly);
            return services;
        }
    }
}
