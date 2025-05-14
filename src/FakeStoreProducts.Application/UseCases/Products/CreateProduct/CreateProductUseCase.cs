using AutoMapper;
using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.ApiClient;
using FakeStoreProducts.Infrastructure.DTOs;

namespace FakeStoreProducts.Application.UseCases.Products.CreateProduct;

/// <summary>
/// Caso de uso para criar um novo produto
/// </summary>
public class CreateProductUseCase : ICreateProductUseCase
{
    private readonly IFakeStoreApiClient _apiClient;
    private readonly IMapper _mapper;

    public CreateProductUseCase(IFakeStoreApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<ProductResponse> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        var productDto = _mapper.Map<ProductDto>(request);

        // Mapeamento específico para campos que têm nomes diferentes
        productDto.Image = request.ImageUrl;

        var createdProduct = await _apiClient.CreateProductAsync(productDto);

        return _mapper.Map<ProductResponse>(createdProduct);
    }

    public async Task<ProductResponse> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(request, cancellationToken);
    }
}