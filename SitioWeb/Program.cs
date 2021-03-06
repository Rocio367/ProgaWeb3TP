using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile($"appsettings.json", false);

                    string entorno = Environment.GetEnvironmentVariable("ENTORNO_TP");
                    if (!string.IsNullOrWhiteSpace(entorno))
                    {
                        builder.AddJsonFile($"{entorno}.appsettings.json", false);
                    }
                });
    }
}
