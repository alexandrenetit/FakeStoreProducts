namespace FakeStoreProducts.Infrastructure.ApiClient.Options;

public class FakeStoreApiOptions
{
    public const string SectionName = "FakeStoreApi";

    /// <summary>
    /// Base URL para a FakeStore API
    /// </summary>
    public string BaseUrl { get; set; } = "https://fakestoreapi.com";

    /// <summary>
    /// Timeout para requisições em segundos
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Define se deve usar retry policy
    /// </summary>
    public bool UseRetryPolicy { get; set; } = true;

    /// <summary>
    /// Número de tentativas de retry
    /// </summary>
    public int RetryCount { get; set; } = 3;
}