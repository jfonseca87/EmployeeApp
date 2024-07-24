using NSubstitute;
using Employees.Domain.Interfaces;
using Employees.Domain.Entities;
using Employees.Application.Services;

namespace Employees.Application.Tests;

public class EmployeeServiceTests
{
    private readonly IEmployeeExternalService mockRepository;
    private readonly IEnumerable<Employee> mockEmployeeList;

    public EmployeeServiceTests()
    {
        mockRepository = Substitute.For<IEmployeeExternalService>();
        mockEmployeeList = GetMockEmployees();
    }

    [Fact]
    public async Task GetEmployeesAsync_ReturnsCorrectEmployeeDtos()
    {
        // Arrange
        mockRepository.GetEmployeesAsync().Returns(Task.FromResult(mockEmployeeList));
        var service = new EmployeeService(mockRepository);

        // Act
        var result = await service.GetEmployeesAsync();

        // Assert
        Assert.NotNull(result);
        var employeeDtos = result.ToList();
        Assert.Equal(2, employeeDtos.Count);

        Assert.Equal(1, employeeDtos[0].Id);
        Assert.Equal("John Doe", employeeDtos[0].Name);
        Assert.Equal(600000, employeeDtos[0].AnnualSalary); 

        Assert.Equal(2, employeeDtos[1].Id);
        Assert.Equal("Jane Smith", employeeDtos[1].Name);
        Assert.Equal(720000, employeeDtos[1].AnnualSalary);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_WhenEmployeeExists_ReturnsEmployeeDto()
    {
        // Arrange
        var expectedEmployee = mockEmployeeList.First();
        mockRepository.GetEmployeeByIdAsync(1).Returns(Task.FromResult(expectedEmployee));
        var service = new EmployeeService(mockRepository);

        // Act
        var result = await service.GetEmployeeByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedEmployee.Id, result!.Id);
        Assert.Equal(expectedEmployee.Name, result.Name);
        Assert.Equal(expectedEmployee.Salary * 12, result.AnnualSalary);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_WhenEmployeeDoesNotExist_ReturnsNull()
    {
        // Arrange
        mockRepository.GetEmployeeByIdAsync(999).Returns(Task.FromResult<Employee>(null!));
        var service = new EmployeeService(mockRepository);

        // Act
        var result = await service.GetEmployeeByIdAsync(2);

        // Assert
        Assert.Null(result);
    }

    private IEnumerable<Employee> GetMockEmployees() =>
        [
            new () { Id = 1, Name = "John Doe", Salary = 50000, Age = 30, ProfileImage = "profile.jpg" },
            new () { Id = 2, Name = "Jane Smith", Salary = 60000, Age = 35, ProfileImage = "avatar.png" }
        ];
}