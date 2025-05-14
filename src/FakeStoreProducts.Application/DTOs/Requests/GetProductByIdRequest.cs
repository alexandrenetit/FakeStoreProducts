namespace FakeStoreProducts.Application.DTOs.Requests;

/// <summary>
/// Requisição para obter um produto por ID
/// </summary>
public record GetProductByIdRequest
{
    /// <summary>
    /// ID do produto a ser obtido
    /// </summary>
    public int ProductId { get; init; }
}