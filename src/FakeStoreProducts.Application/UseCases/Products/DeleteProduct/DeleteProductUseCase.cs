using FakeStoreProducts.Application.Common.Exceptions;
using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.ApiClient;

namespace FakeStoreProducts.Application.UseCases.Products.DeleteProduct;

/// <summary>
/// Caso de uso para excluir um produto
/// </summary>
public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IFakeStoreApiClient _apiClient;

    public DeleteProductUseCase(IFakeStoreApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<BaseResponse> ExecuteAsync(DeleteProductRequest request, CancellationToken cancellationToken = default)
    {
        // Verificar se o produto existe
        var product = await _apiClient.GetProductByIdAsync(request.ProductId);

        if (product == null)
        {
            throw new NotFoundException(nameof(product), request.ProductId);
        }

        var result = await _apiClient.DeleteProductAsync(request.ProductId);

        if (!result)
        {
            return new ErrorResponse("Não foi possível excluir o produto");
        }

        return new SuccessResponse("Produto excluído com sucesso");
    }

    public async Task<BaseResponse> HandleAsync(DeleteProductRequest request, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(request, cancellationToken);
    }
}