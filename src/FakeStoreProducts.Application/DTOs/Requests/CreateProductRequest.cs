namespace FakeStoreProducts.Application.DTOs.Requests;

/// <summary>
/// Requisição para criar um novo produto
/// </summary>
public record CreateProductRequest
{
    /// <summary>
    /// Título do produto
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Preço do produto
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Categoria do produto
    /// </summary>
    public string Category { get; init; } = string.Empty;

    /// <summary>
    /// URL da imagem do produto
    /// </summary>
    public string ImageUrl { get; init; } = string.Empty;
}