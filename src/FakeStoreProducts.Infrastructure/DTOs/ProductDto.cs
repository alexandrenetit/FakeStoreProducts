using System.Text.Json.Serialization;

namespace FakeStoreProducts.Infrastructure.DTOs;

/// <summary>
/// DTO para representar um produto da FakeStore API
/// </summary>
public class ProductDto
{
    /// <summary>
    /// ID do produto
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Título do produto
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Preço do produto
    /// </summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Categoria do produto
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// URL da imagem do produto
    /// </summary>
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;
}