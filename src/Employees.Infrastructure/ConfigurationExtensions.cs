using Employees.Domain.Interfaces;
using Employees.Infrastructure.Services;
using Employees.Infrastructure.ThirdPartyDataService.RestApiExample;
using Employees.Infrastructure.ThirdPartyDataService.RestApiExample.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEmployeeExternalService, EmployeeExternalService>();

        string restApiExampleUrl = configuration["RestApiExampleUrl"]!;
        if (string.IsNullOrEmpty(restApiExampleUrl))
        {
            throw new KeyNotFoundException($"The key RestApiExampleUrl does not exists in app settings");
        }

        services.AddHttpClient<IRestApiExampleClient, RestApiExampleClient>((client) =>
        {
            client.BaseAddress = new Uri(restApiExampleUrl);
        });

        return services;
    }
}
