using FileData.Interfaces;
using FileData.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ThirdPartyTools;

namespace FileData.Framework
{
    public class ServiceCollectionExtensions
    {
        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                .AddScoped<IFileDetailsService, FileDetailsService>()
                .AddScoped<IValidator, Validator>()
                .AddScoped<IExecuter, Executer>()
                .AddScoped<FileDetails, FileDetails>())
            .ConfigureLogging(loggingBuilder => 
            {
                loggingBuilder.AddSerilog();
            });
    }
}
