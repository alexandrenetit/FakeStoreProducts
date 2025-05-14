namespace FakeStoreProducts.Application.DTOs.Requests;

/// <summary>
/// Requisição para atualizar um produto existente
/// </summary>
public record UpdateProductRequest
{
    /// <summary>
    /// ID do produto a ser atualizado
    /// </summary>
    public int ProductId { get; init; }

    /// <summary>
    /// Título atualizado do produto
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Preço atualizado do produto
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Descrição atualizada do produto
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Categoria atualizada do produto
    /// </summary>
    public string Category { get; init; } = string.Empty;

    /// <summary>
    /// URL da imagem atualizada do produto
    /// </summary>
    public string ImageUrl { get; init; } = string.Empty;
}