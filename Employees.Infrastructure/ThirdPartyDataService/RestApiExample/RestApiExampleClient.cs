using Employees.Infrastructure.Abstractions;
using Employees.Infrastructure.ThirdPartyDataService.RestApiExample.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Employees.Infrastructure.ThirdPartyDataService.RestApiExample;

public sealed class RestApiExampleClient(HttpClient httpClient, ILogger<RestApiExampleClient> logger) : IRestApiExampleClient
{
    public async Task<T> ExecuteCommandAsync<T>(IClientCommand command) where T : class
    {
        T responseData = default!;

        try
        {
            var response = await SendRequestInternalAsync(command.Method, command.Url!, command.Payload!);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("An error ocurred getting information {Error}", response.ReasonPhrase);
                return responseData;
            }

            var content = await response.Content.ReadAsStringAsync();
            var contentResponse = JsonSerializer.Deserialize<RestApiExampleResponse<T>>(content, GetSerializerOptions())!;
            responseData = contentResponse.Data;
        }
        catch (Exception ex)
        {
            logger.LogError("An error ocurred getting information {Error}", ex.Message);
        }

        return responseData!;
    }

    private async Task<HttpResponseMessage> SendRequestInternalAsync(HttpMethod method, string requestUri, object payload)
    {
        var requestJson = payload is not null ? JsonSerializer.Serialize(payload) : string.Empty;
        var request = new HttpRequestMessage(method, requestUri);

        if (!string.IsNullOrEmpty(requestJson))
        {
            request.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        }

        return await httpClient.SendAsync(request);
    }

    private static JsonSerializerOptions GetSerializerOptions() =>
        new()
        {
            PropertyNameCaseInsensitive = true,
        };

}
