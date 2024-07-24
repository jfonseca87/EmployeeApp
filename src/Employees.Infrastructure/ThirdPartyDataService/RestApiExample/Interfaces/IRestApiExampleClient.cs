using Employees.Infrastructure.Abstractions;

namespace Employees.Infrastructure.ThirdPartyDataService.RestApiExample.Interfaces
{
    public interface IRestApiExampleClient
    {
        Task<T> ExecuteCommandAsync<T>(IClientCommand command) where T : class;
    }
}