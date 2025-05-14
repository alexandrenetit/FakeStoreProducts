using AutoMapper;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.ApiClient;

namespace FakeStoreProducts.Application.UseCases.Products.GetAllProducts;

/// <summary>
/// Caso de uso para obter todos os produtos
/// </summary>
public class GetAllProductsUseCase : IGetAllProductsUseCase
{
    private readonly IFakeStoreApiClient _apiClient;
    private readonly IMapper _mapper;

    public GetAllProductsUseCase(IFakeStoreApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<ProductListResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var products = await _apiClient.GetAllProductsAsync();

        var productResponses = products
            .Select(p => _mapper.Map<ProductResponse>(p))
            .ToList();

        return new ProductListResponse(productResponses);
    }

    public async Task<ProductListResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(cancellationToken);
    }
}