using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Core.Application_.Repositories;
using Pet.Infrastructure.Context;
using Pet.Infrastructure.Repositories;
using System.Diagnostics;

namespace Pet.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfDbContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("EfDbContext"))
                  .LogTo(x => Debug.WriteLine(x));
                x.EnableSensitiveDataLogging();
            });         
            services.AddScoped<DbContext, EfDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
