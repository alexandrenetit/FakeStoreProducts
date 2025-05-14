using FakeStoreProducts.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace FakeStoreProducts.Infrastructure.Services;

/// <summary>
/// Serviço para realizar requisições HTTP
/// </summary>
public class HttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpClientService> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public HttpClientService(HttpClient httpClient, ILogger<HttpClientService> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    /// <summary>
    /// Realiza uma requisição GET e converte a resposta para o tipo T
    /// </summary>
    public async Task<T?> GetAsync<T>(string url)
    {
        return await HttpExceptionHandlerExtensions.ExecuteWithExceptionHandlingAsync(async () =>
        {
            _logger.LogInformation("Realizando GET para {Url}", url);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }, url);
    }

    /// <summary>
    /// Realiza uma requisição POST com o objeto data no corpo e converte a resposta para o tipo T
    /// </summary>
    public async Task<T?> PostAsync<T>(string url, object data)
    {
        return await HttpExceptionHandlerExtensions.ExecuteWithExceptionHandlingAsync(async () =>
        {
            _logger.LogInformation("Realizando POST para {Url}", url);

            var content = new StringContent(
                JsonSerializer.Serialize(data, _jsonOptions),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }, url);
    }

    /// <summary>
    /// Realiza uma requisição PUT com o objeto data no corpo e converte a resposta para o tipo T
    /// </summary>
    public async Task<T?> PutAsync<T>(string url, object data)
    {
        return await HttpExceptionHandlerExtensions.ExecuteWithExceptionHandlingAsync(async () =>
        {
            _logger.LogInformation("Realizando PUT para {Url}", url);

            var content = new StringContent(
                JsonSerializer.Serialize(data, _jsonOptions),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }, url);
    }

    /// <summary>
    /// Realiza uma requisição DELETE e retorna um booleano indicando o sucesso da operação
    /// </summary>
    public async Task<bool> DeleteAsync(string url)
    {
        return await HttpExceptionHandlerExtensions.ExecuteWithExceptionHandlingAsync(async () =>
        {
            _logger.LogInformation("Realizando DELETE para {Url}", url);

            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return true;
        }, url);
    }
}