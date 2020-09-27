﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFL.BigDataBowl.Services;
using NFL.BigDataBowl.Utilities;

namespace NFL.BigDataBowl
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddCommandLine(args);
                    // config.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<RushingService>()
                        .AddSingleton(typeof(Requester));
                })
                .UseConsoleLifetime();
        }
    }
}