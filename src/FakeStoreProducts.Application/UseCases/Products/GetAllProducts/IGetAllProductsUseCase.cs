using FakeStoreProducts.Application.DTOs.Responses;

namespace FakeStoreProducts.Application.UseCases.Products.GetAllProducts;

/// <summary>
/// Interface para o caso de uso de obtenção de todos os produtos
/// </summary>
public interface IGetAllProductsUseCase
{
    /// <summary>
    /// Executa o caso de uso para obter todos os produtos
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Resposta contendo a lista de produtos</returns>
    Task<ProductListResponse> ExecuteAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Manipula a requisição para obter todos os produtos
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Resposta contendo a lista de produtos</returns>
    Task<ProductListResponse> HandleAsync(CancellationToken cancellationToken = default);
}