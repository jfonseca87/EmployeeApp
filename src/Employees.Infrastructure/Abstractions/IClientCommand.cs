namespace Employees.Infrastructure.Abstractions;

public interface IClientCommand
{
    public HttpMethod Method { get; }
    public string? Url { get; }
    public object? Payload { get; }
}
