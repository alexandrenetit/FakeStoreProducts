using FakeStoreProducts.Infrastructure.ApiClient.Options;
using FakeStoreProducts.Infrastructure.DTOs;
using FakeStoreProducts.Infrastructure.Exceptions;
using FakeStoreProducts.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FakeStoreProducts.Infrastructure.ApiClient;

/// <summary>
/// Implementação do cliente para a FakeStore API que utiliza o HttpClientService
/// </summary>
public class FakeStoreApiClient : IFakeStoreApiClient
{
    private readonly HttpClientService _httpClientService;
    private readonly ILogger<FakeStoreApiClient> _logger;
    private readonly string _baseUrl;

    public FakeStoreApiClient(
        HttpClientService httpClientService,
        IOptions<FakeStoreApiOptions> options,
        ILogger<FakeStoreApiClient> logger)
    {
        _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        var apiOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _baseUrl = apiOptions.BaseUrl;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        _logger.LogFetchingAllProducts();

        var products = await _httpClientService.GetAsync<List<ProductDto>>("products");
        return products ?? new List<ProductDto>();
    }

    /// <inheritdoc />
    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        _logger.LogFetchingProductById(id);

        try
        {
            return await _httpClientService.GetAsync<ProductDto>($"products/{id}");
        }
        catch (Exception ex) when (ex.Message.Contains("404") || ex.Message.Contains("Not Found"))
        {
            _logger.LogWarning("Produto com ID {ProductId} não encontrado", id);
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        _logger.LogCreatingProduct(productDto.Title);

        var createdProduct = await _httpClientService.PostAsync<ProductDto>("products", productDto);
        return createdProduct ?? throw new InvalidOperationException("Não foi possível criar o produto");
    }

    /// <inheritdoc />
    public async Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto)
    {
        _logger.LogUpdatingProduct(id);

        try
        {
            var updatedProduct = await _httpClientService.PutAsync<ProductDto>($"products/{id}", productDto);
            return updatedProduct ?? throw new InvalidOperationException("Não foi possível atualizar o produto");
        }
        catch (Exception ex) when (ex.Message.Contains("404") || ex.Message.Contains("Not Found"))
        {
            _logger.LogWarning("Produto com ID {ProductId} não encontrado para atualização", id);
            throw new KeyNotFoundException($"Produto com ID {id} não encontrado");
        }
    }

    /// <inheritdoc />
    public async Task<bool> DeleteProductAsync(int id)
    {
        _logger.LogDeletingProduct(id);

        try
        {
            return await _httpClientService.DeleteAsync($"products/{id}");
        }
        catch (Exception ex) when (ex.Message.Contains("404") || ex.Message.Contains("Not Found"))
        {
            _logger.LogWarning("Produto com ID {ProductId} não encontrado para exclusão", id);
            return false;
        }
    }
}