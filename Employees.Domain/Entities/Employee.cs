using System.Text.Json.Serialization;

namespace Employees.Domain.Entities;

public sealed class Employee : BaseEntity<int>
{
    [JsonPropertyName("employee_name")]
    public string? Name { get; set; }

    [JsonPropertyName("employee_salary")]
    public decimal Salary { get; set; }

    [JsonPropertyName("employee_age")]
    public int Age { get; set; }

    [JsonPropertyName("profile_image")]
    public string? ProfileImage { get; set; }
}
