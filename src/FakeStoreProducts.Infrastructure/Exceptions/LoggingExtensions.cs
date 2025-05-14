using Microsoft.Extensions.Logging;

namespace FakeStoreProducts.Infrastructure.Exceptions;

// <summary>
/// Extensões para melhorar a experiência de logging
/// </summary>
public static class LoggingExtensions
{
    // Define IDs de evento para diferentes operações
    private static readonly EventId FetchAllProducts = new(1000, "FetchAllProducts");

    private static readonly EventId FetchProductById = new(1001, "FetchProductById");
    private static readonly EventId CreateProduct = new(1002, "CreateProduct");
    private static readonly EventId UpdateProduct = new(1003, "UpdateProduct");
    private static readonly EventId DeleteProduct = new(1004, "DeleteProduct");
    private static readonly EventId ApiError = new(1005, "ApiError");

    /// <summary>
    /// Loga o início da busca de todos os produtos
    /// </summary>
    public static void LogFetchingAllProducts(this ILogger logger)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(FetchAllProducts, "Buscando todos os produtos da API");
        }
    }

    /// <summary>
    /// Loga o início da busca de um produto por ID
    /// </summary>
    public static void LogFetchingProductById(this ILogger logger, int productId)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(FetchProductById, "Buscando produto com ID {ProductId}", productId);
        }
    }

    /// <summary>
    /// Loga o início da criação de um produto
    /// </summary>
    public static void LogCreatingProduct(this ILogger logger, string productTitle)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(CreateProduct, "Criando produto: {ProductTitle}", productTitle);
        }
    }

    /// <summary>
    /// Loga o início da atualização de um produto
    /// </summary>
    public static void LogUpdatingProduct(this ILogger logger, int productId)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(UpdateProduct, "Atualizando produto com ID {ProductId}", productId);
        }
    }

    /// <summary>
    /// Loga o início da exclusão de um produto
    /// </summary>
    public static void LogDeletingProduct(this ILogger logger, int productId)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(DeleteProduct, "Excluindo produto com ID {ProductId}", productId);
        }
    }

    /// <summary>
    /// Loga um erro de comunicação com a API
    /// </summary>
    public static void LogApiError(this ILogger logger, Exception ex, string operation, string details = "")
    {
        logger.LogError(
            ApiError,
            ex,
            "Erro na operação {Operation}. {Details}. Mensagem: {Message}",
            operation,
            details,
            ex.Message);
    }
}