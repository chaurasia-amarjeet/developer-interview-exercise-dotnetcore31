using FileData.Framework;
using FileData.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/FileData.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello...");

            IHost host = ServiceCollectionExtensions.CreateHostBuilder(args).Build();

            var executer = host.Services.GetService<IExecuter>();

            executer.Execute(args);

            Console.ReadKey();
        }
    }
}
