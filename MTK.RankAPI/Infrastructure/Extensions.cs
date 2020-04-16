using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTK.RankAPI.Data;
using System;
using System.Reflection;

namespace MTK.RankAPI.Infrastructure
{
    public static class RankServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var server = configuration["DBServer"] ?? "ms-sql-server";
            //var port = configuration["DBPort"] ?? "1433";
            //var user = configuration["DBUser"] ?? "SA";
            //var password = configuration["DBPassword"] ?? "!Docker123";
            //var database = configuration["Database"] ?? "MTK.RankServiceDb";

            //var connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}";

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
        }
    }
}