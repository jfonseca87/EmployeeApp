using Employees.Domain.Entities;
using Employees.Domain.Interfaces;
using Employees.Infrastructure.ThirdPartyDataService.RestApiExample;
using Employees.Infrastructure.ThirdPartyDataService.RestApiExample.Interfaces;
using Microsoft.Extensions.Logging;

namespace Employees.Infrastructure.Services;

public sealed class EmployeeExternalService(IRestApiExampleClient client, ILogger<EmployeeExternalService> logger) : IEmployeeExternalService
{
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        logger.LogInformation("Getting employees information");

        var clientConfiguration = new RestApiExampleClientCommand
        {
            Url = "v1/employees"
        };

        var employees = await client.ExecuteCommandAsync<IEnumerable<Employee>>(clientConfiguration);
        return employees;
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        logger.LogInformation("Getting employee information with id: {Id}", id);

        var clientConfiguration = new RestApiExampleClientCommand
        {
            Url = $"v1/employee/{id}"
        };

        var employee = await client.ExecuteCommandAsync<Employee>(clientConfiguration);
        return employee;
    }
}
