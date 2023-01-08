using Data.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Interfaces;

var builder = CreateHostBuilder(args);

// Setup before building
builder.ConfigureAppConfiguration((context, builder) =>
{
    SetUpAppConfiguration(builder);
});
builder.ConfigureServices((context, services) =>
{
    ConfigureAppSettings(context, services);
    SetUpDepedencyInjection(services);
});

var app = builder.Build();

try
{
    app.Services.GetRequiredService<CommandService>().Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

////---------------------------------------------------------------------
//  Methods
////---------------------------------------------------------------------

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args);
}

// Build IConfigurationRoot from AppSettings.json to get all necessary AppSettings values
void SetUpAppConfiguration(IConfigurationBuilder builder)
{
    var configuration = builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

    IConfigurationRoot configurationRoot = configuration.Build();
}

// Configure AppSettings class into services, to be able to access it via dependency injection of IOptions
void ConfigureAppSettings(HostBuilderContext context, IServiceCollection services)
{
    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
}

// Setup of dependency injection of interface and their correlated services.
void SetUpDepedencyInjection(IServiceCollection services)
{
    services.AddSingleton<CommandService>();
    services.AddSingleton<IStringsService, StringsService>();
    services.AddSingleton<INumbersService, NumbersService>();
    services.AddSingleton<IArraysService, ArraysService>();
    services.AddSingleton<IDataStructuresService, DataStructuresService>();
}