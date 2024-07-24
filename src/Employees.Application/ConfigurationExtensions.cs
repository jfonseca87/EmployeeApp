using Employees.Application.Services;
using Employees.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeService, EmployeeService>();

        return services;
    }
}
