using AutoMapper;
using FakeStoreProducts.Application.Common.Exceptions;
using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.ApiClient;

namespace FakeStoreProducts.Application.UseCases.Products.GetProductById;

/// <summary>
/// Caso de uso para obter um produto por ID
/// </summary>
public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IFakeStoreApiClient _apiClient;
    private readonly IMapper _mapper;

    public GetProductByIdUseCase(IFakeStoreApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<ProductResponse> ExecuteAsync(GetProductByIdRequest request, CancellationToken cancellationToken = default)
    {
        var product = await _apiClient.GetProductByIdAsync(request.ProductId);

        if (product == null)
        {
            throw new NotFoundException(nameof(product), request.ProductId);
        }

        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<ProductResponse> HandleAsync(GetProductByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(request, cancellationToken);
    }
}