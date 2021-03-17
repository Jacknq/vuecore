using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.CodeAnalysis;
//using TextTemplating.Infrastructure;


namespace WebApplication2Vue
{
    public class Program
    {
        public static IConfigurationRoot config { get; set; }

        public static void Main(string[] args)
        {

            // Retrieve the configuration information.

            // Retrieve the configuration information.
            Startup.config = config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
            //j

            var host = Host.CreateDefaultBuilder(args)//new WebHostBuilder()
                .ConfigureAppConfiguration(builder => builder.AddConfiguration(config))
                //  .ConfigureLogging((hostingContext, logging) =>
                // {
                //     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //     logging.AddDebug();
                //     logging.AddNLog();
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseWebRoot("dist");
                    // webBuilder.UseIISIntegration();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseKestrel();
                    //webBuilder.UseNLog();
                    webBuilder.UseStartup<Startup>();
                });

            RunSomeTasks();

            // Log.Debug("caaling host run");
            host.Build().Run();

        }

        private static void RunSomeTasks()
        {
            //testc t = new testc();
         
        }
        
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
