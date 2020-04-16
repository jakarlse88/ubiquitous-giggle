using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Data.SqlClient;
using System;
using Polly;
using MTK.RankAPI.Models;

namespace MTK.RankAPI.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // SeedData(serviceScope.ServiceProvider.GetService<RankServiceDbContext>());

                try
                {
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(new TimeSpan[]
                        {
                                TimeSpan.FromSeconds(120),
                                TimeSpan.FromSeconds(90),
                                TimeSpan.FromSeconds(60),
                                TimeSpan.FromSeconds(30)
                        });

                    //if the sql server container is not created on run docker compose this
                    //migration can't fail for network related exception. The retry options for DbContext only
                    //apply to transient exceptions
                    // Note that this is NOT applied when running some orchestrators (let the orchestrator to recreate the failing service)
                    retry.Execute(() => SeedData(serviceScope.ServiceProvider.GetService<RankServiceDbContext>()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Migration failed.", ex);
                    throw;
                }
            }
        }

        private static void SeedData(RankServiceDbContext context)
        {
            Console.WriteLine("Applying migrations...");

            context.Database.Migrate();

            Console.WriteLine("Migrations applied.");

            if (!context.AgeGroup.Any())
            {
                Console.WriteLine("Data not present, seeding database.");

                context.AgeGroup.AddRange(
                    new AgeGroup
                    {
                        Name = "Red"
                    },
                    new AgeGroup
                    {
                        Name = "Blue"
                    },
                    new AgeGroup
                    {
                        Name = "Green"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already present, not seeding.");
            }
        }
    }
}