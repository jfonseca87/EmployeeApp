using Employees.Domain.Entities;

namespace Employees.Domain.Interfaces;

public interface IEmployeeExternalService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
}
