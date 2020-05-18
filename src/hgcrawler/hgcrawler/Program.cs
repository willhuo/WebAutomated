using hgcrawler.services;
using hgcrawler.util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace hgcrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Init.AutoConfig();
                Log.Warning("HG Crawler Starting up");

                HostBuild(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHost HostBuild(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("appsettings.json", false, reloadOnChange: true);
                    configHost.AddEnvironmentVariables();
                    configHost.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.AddHttpClient();
                    services.AddSingleton<IDriverHelper, ChromeDriverHelper>();
                    services.AddSingleton<IWebdriverAction, WebdriverAction>();
                    services.AddHostedService<_1688Service>();
                })                
                .UseConsoleLifetime()
                .Build();
            return host;
        }
    }
}
