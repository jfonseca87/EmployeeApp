using Employees.Infrastructure;
using Employees.Application;
using Microsoft.AspNetCore.Mvc;
using Employees.Application.Services.Interfaces;
using Employees.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/employees", async ([FromServices] IEmployeeService employeeService) =>
{
    return await employeeService.GetEmployeesAsync();
})
.WithName("GetEmployeesAsync")
.WithOpenApi();

app.MapGet("/employees/{id}", async ([FromServices] IEmployeeService employeeService, [FromRoute] int id) =>
{
    var result = await employeeService.GetEmployeeByIdAsync(id);
    if (result is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(result);
})
.WithName("GetEmployeeByIdAsync")
.WithOpenApi();

await app.RunAsync();
