namespace FakeStoreProducts.Application.DTOs.Responses;

/// <summary>
/// Resposta contendo uma lista de produtos
/// </summary>
public record ProductListResponse : BaseResponse
{
    /// <summary>
    /// Inicializa uma nova instância de ProductListResponse
    /// </summary>
    /// <param name="products">Lista de produtos</param>
    public ProductListResponse(IEnumerable<ProductResponse> products)
    {
        Success = true;
        Products = products;
    }

    /// <summary>
    /// Lista de produtos
    /// </summary>
    public IEnumerable<ProductResponse> Products { get; }
}