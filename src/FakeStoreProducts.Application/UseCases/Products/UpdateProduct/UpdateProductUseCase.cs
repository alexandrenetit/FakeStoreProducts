using AutoMapper;
using FakeStoreProducts.Application.Common.Exceptions;
using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.ApiClient;
using FakeStoreProducts.Infrastructure.DTOs;

namespace FakeStoreProducts.Application.UseCases.Products.UpdateProduct;

/// <summary>
/// Caso de uso para atualizar um produto
/// </summary>
public class UpdateProductUseCase : IUpdateProductUseCase
{
    private readonly IFakeStoreApiClient _apiClient;
    private readonly IMapper _mapper;

    public UpdateProductUseCase(IFakeStoreApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<ProductResponse> ExecuteAsync(UpdateProductRequest request, CancellationToken cancellationToken = default)
    {
        // Verificar se o produto existe
        var existingProduct = await _apiClient.GetProductByIdAsync(request.ProductId);

        if (existingProduct == null)
        {
            throw new NotFoundException(nameof(existingProduct), request.ProductId);
        }

        var productDto = _mapper.Map<ProductDto>(request);
        productDto.Id = request.ProductId;
        productDto.Image = request.ImageUrl;

        var updatedProduct = await _apiClient.UpdateProductAsync(request.ProductId, productDto);

        return _mapper.Map<ProductResponse>(updatedProduct);
    }

    public async Task<ProductResponse> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(request, cancellationToken);
    }
}