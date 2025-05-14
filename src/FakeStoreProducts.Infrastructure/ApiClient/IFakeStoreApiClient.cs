using FakeStoreProducts.Infrastructure.DTOs;

namespace FakeStoreProducts.Infrastructure.ApiClient;

public interface IFakeStoreApiClient
{
    /// <summary>
    /// Obtém todos os produtos da API
    /// </summary>
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();

    /// <summary>
    /// Obtém um produto específico pelo ID
    /// </summary>
    Task<ProductDto?> GetProductByIdAsync(int id);

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    Task<ProductDto> CreateProductAsync(ProductDto productDto);

    /// <summary>
    /// Atualiza um produto existente
    /// </summary>
    Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto);

    /// <summary>
    /// Exclui um produto
    /// </summary>
    Task<bool> DeleteProductAsync(int id);
}