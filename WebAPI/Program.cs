using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using WebAPI.Extensions;


namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .ConfigureAppConfiguration((hostingContext, config) =>
            //    {
            //        var env = hostingContext.HostingEnvironment;
            //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //        config.AddEnvironmentVariables();
            //    })
            //    .ConfigureLogging((hostingContext, logging) =>
            //    {
            //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            //        logging.AddConsole();
            //        logging.AddDebug();
            //        logging.AddEventSourceLogger();
            //    })
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                var host = await CreateHostBuilder(args)
                    .Build()
                    .SeedData();

                host.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}