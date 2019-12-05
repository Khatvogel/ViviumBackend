using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//                try
//                {
//                    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
//                    applicationDbContext.Database.Migrate();
//                    ApplicationDbSeed.SeedAsync(applicationDbContext)
//                        .Wait();
//                }
//                catch (Exception ex)
//                {
//                    var logger = loggerFactory.CreateLogger<Program>();
//                    logger.LogError(ex, "An error occurred seeding the DB.");
//                }
//            }
//
//            host.Run();
        }


        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}