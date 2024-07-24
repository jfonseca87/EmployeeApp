using System.Text.Json.Serialization;

namespace Employees.Infrastructure.ThirdPartyDataService.RestApiExample;

public sealed class RestApiExampleResponse<T>
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
