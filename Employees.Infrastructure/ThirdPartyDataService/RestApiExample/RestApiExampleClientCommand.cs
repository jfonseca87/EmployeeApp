using Employees.Infrastructure.Abstractions;

namespace Employees.Infrastructure.ThirdPartyDataService.RestApiExample;

public sealed class RestApiExampleClientCommand : IClientCommand
{
    public HttpMethod Method { get; set; } = HttpMethod.Get;
    public string Url { get; set; } = string.Empty;
    public object? Payload { get; set; } = default!;
}
