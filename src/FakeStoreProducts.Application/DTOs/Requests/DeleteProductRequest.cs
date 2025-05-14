namespace FakeStoreProducts.Application.DTOs.Requests;

/// <summary>
/// Requisição para excluir um produto
/// </summary>
public record DeleteProductRequest
{
    /// <summary>
    /// ID do produto a ser excluído
    /// </summary>
    public int ProductId { get; init; }
}