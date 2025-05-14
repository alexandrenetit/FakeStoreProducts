namespace FakeStoreProducts.Application.DTOs.Responses;

/// <summary>
/// Resposta contendo informações de um produto
/// </summary>
public record ProductResponse : BaseResponse
{
    /// <summary>
    /// Inicializa uma nova instância de ProductResponse
    /// </summary>
    public ProductResponse()
    {
        Success = true;
    }

    /// <summary>
    /// ID do produto
    /// </summary>
    public int Id { get; init; }

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