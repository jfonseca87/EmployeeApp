using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Interfaces;

namespace Employees.Application.Services;

public sealed class EmployeeService(IEmployeeExternalService employeeRepository) : IEmployeeService
{
    private const int AnnualMonths = 12;

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        IEnumerable<Employee> result = await employeeRepository.GetEmployeesAsync() ?? [];
        return result.Select(x => new EmployeeDto(x.Id, x.Name!, x.Salary, x.Age, x.ProfileImage!, x.Salary * AnnualMonths)).ToList();
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
    {
        Employee result = await employeeRepository.GetEmployeeByIdAsync(id);
        var response = result is not null 
            ? new EmployeeDto(result.Id, result.Name!, result.Salary, result.Age, result.ProfileImage!, result.Salary * AnnualMonths)
            : null;

        return response;
    }
}
