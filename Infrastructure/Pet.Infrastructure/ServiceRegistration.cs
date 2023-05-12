﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}