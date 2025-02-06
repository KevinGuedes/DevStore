using Ambev.DeveloperEvaluation.Integration.SharedContexts;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Integration.Common;

/// <summary>
/// Base class for integration tests
/// </summary>
[Collection(nameof(ApplicationFactoryCollection))]
public abstract class BaseIntegrationTest : IDisposable
{
    private readonly string _baseUrl;
    private readonly IServiceScope _scope;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpClient _httpClient;
    private readonly DefaultContext _dbContext;

    protected BaseIntegrationTest(ApplicationFactory applicationFactory, string baseUrl)
    {
        _baseUrl = baseUrl;
        _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        };

        _httpClient = applicationFactory.CreateClient();

        _scope = applicationFactory.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<DefaultContext>();
    }

    /// <summary>
    /// Sends a POST request to the API
    /// </summary>
    /// <typeparam name="TResponse">The deserialized result if any and if the response is successful</typeparam>
    /// <param name="requestUrl">The request URL</param>
    /// <returns>The HTTP Response Message and the deserialized response data</returns>
    protected async Task<(HttpResponseMessage, TResponse?)> PostAsync<TRequest, TResponse>(
        TRequest request,
        string? requestUrl = null)
    {
        var response = await _httpClient.PostAsJsonAsync(GetEndpoint(requestUrl), request);
        return await HandleHttpResponse<TResponse>(response);
    }

    /// <summary>
    /// Sends a GET request to the API
    /// </summary>
    /// <typeparam name="TResponse">The deserialized result if any and if the response is successful</typeparam>
    /// <param name="requestUrl">The request URL</param>
    /// <returns>The HTTP Response Message and the deserialized response data</returns>
    protected async Task<(HttpResponseMessage, TResponse?)> GetAsync<TResponse>(string? requestUrl = null)
    {
        var response = await _httpClient.GetAsync(GetEndpoint(requestUrl));
        return await HandleHttpResponse<TResponse>(response);
    }

    /// <summary>
    /// Verifies the payload of the response
    /// </summary>
    /// <param name="response">The HTTP response</param>
    protected static async Task VerifyResponsePayloadAsync(HttpResponseMessage response)
    {
        if (response.Content.Headers.ContentLength is 0)
            return;

        var responseContent = await response.Content.ReadAsStringAsync();

        DerivePathInfo((_, projectDirectory, type, method) =>
        {
            return new PathInfo(
                Path.Combine(projectDirectory, "ResponseSnapshots", type.Name),
                type.Name,
                method.Name);
        });

        await VerifyJson(responseContent).UseStrictJson();
    }

    /// <summary>
    /// Builds the api endpoint URL
    /// </summary>
    /// <param name="requestUrl">The request url</param>
    /// <returns>The full URL for the endpoint</returns>
    private string GetEndpoint(string? requestUrl)
        => requestUrl is null ? _baseUrl : $"{_baseUrl}/{requestUrl}";

    /// <summary>
    /// Handles the HTTP response and deserializes the result if any and if the response is successful
    /// </summary>
    /// <typeparam name="TResponse">The deserialized result if any and if the response is successful</typeparam>
    /// <param name="response">The HTTP Response message</param>
    //Bad requests can have payload too, but for now, only handling happy paths
    private async ValueTask<(HttpResponseMessage, TResponse?)> HandleHttpResponse<TResponse>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength is not 0)
        {
            var responseDataAsJson = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<TResponse>(responseDataAsJson, _jsonSerializerOptions);

            return (response, responseData);
        }

        return (response, default);
    }

    public void Dispose()
    {
        _scope?.Dispose();
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}