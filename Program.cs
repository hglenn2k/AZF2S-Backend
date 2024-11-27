using AZF2S_Backend.Service.ThirdParty;
using AZF2S_Backend.Service.ThirdParty.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Third-party services
        services.AddScoped<IAppInsightsService, AppInsightsService>();
        services.AddScoped<IMongoDbService, MongoDbService>();
        services.AddScoped<IGoogleSheetService, GoogleSheetService>();
        services.AddScoped<IMailchimpService, MailchimpService>();
        services.AddScoped<INodeBbService, NodeBbService>();
        services.AddScoped<IBrevoService, BrevoService>();
    })
    .Build();

host.Run();