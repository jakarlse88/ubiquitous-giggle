using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTK.RankAPI.Data;
using System;
using System.Reflection;
using MassTransit;

namespace MTK.RankAPI.Infrastructure
{
    public static class RankServiceExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RankServiceDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"], sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions
                        .MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);

                    sqlOptions
                        .EnableRetryOnFailure(
                            maxRetryCount: 15,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                });
            });

            return services;
        }

        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);

                    cfg.Host("rabbitmq://localhost");

                    //cfg.ReceiveEndpoint
                }));
            });

            return services;
        }
    }
}