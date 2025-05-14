using AutoMapper;
using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Domain.Entities;
using FakeStoreProducts.Infrastructure.ApiClient;
using FakeStoreProducts.Infrastructure.DTOs;
using FakeStoreProducts.Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace FakeStoreProducts.Application.UseCases.Products.CreateProduct;

/// <summary>
/// Caso de uso para criar um novo produto
/// </summary>
public class CreateProductUseCase : ICreateProductUseCase
{
    private readonly IFakeStoreApiClient _apiClient;
    private readonly IMapper _mapper;
    private readonly IMessageBusService _messageBusService;
    private readonly ILogger<CreateProductUseCase> _logger;

    public CreateProductUseCase(
        IFakeStoreApiClient apiClient,
        IMapper mapper,
        IMessageBusService messageBusService,
        ILogger<CreateProductUseCase> logger)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _messageBusService = messageBusService ?? throw new ArgumentNullException(nameof(messageBusService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ProductResponse> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var productDto = _mapper.Map<ProductDto>(request);
            // Mapeamento específico para campos que têm nomes diferentes
            productDto.Image = request.ImageUrl;

            var createdProduct = await _apiClient.CreateProductAsync(productDto);

            // Criar a entidade de domínio para publicar o evento
            var product = new Product(
                createdProduct.Id,
                createdProduct.Title,
                createdProduct.Price,
                createdProduct.Description,
                createdProduct.Category,
                createdProduct.Image
            );

            // Publicar o evento de produto criado
            await _messageBusService.PublishProductCreatedEventAsync(product, cancellationToken);

            return _mapper.Map<ProductResponse>(createdProduct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar produto: {Title}", request.Title);
            throw;
        }
    }

    public async Task<ProductResponse> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(request, cancellationToken);
    }
}