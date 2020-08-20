using MediatrSample.Domain.Repository;
using MediatrSample.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddDbContext<MediatrSampleDbContext>(options => 
                options.UseInMemoryDatabase("ClientDb"));

            return services;
        }
    }
}
