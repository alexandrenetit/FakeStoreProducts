using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Application.UseCases.Products.CreateProduct;
using FakeStoreProducts.Application.UseCases.Products.DeleteProduct;
using FakeStoreProducts.Application.UseCases.Products.GetAllProducts;
using FakeStoreProducts.Application.UseCases.Products.GetProductById;
using FakeStoreProducts.Application.UseCases.Products.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProducts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ICreateProductUseCase _createProductUseCase;
    private readonly IGetProductByIdUseCase _getProductByIdUseCase;
    private readonly IGetAllProductsUseCase _getAllProductsUseCase;
    private readonly IUpdateProductUseCase _updateProductUseCase;
    private readonly IDeleteProductUseCase _deleteProductUseCase;

    public ProductsController(
        ICreateProductUseCase createProductUseCase,
        IGetProductByIdUseCase getProductByIdUseCase,
        IGetAllProductsUseCase getAllProductsUseCase,
        IUpdateProductUseCase updateProductUseCase,
        IDeleteProductUseCase deleteProductUseCase)
    {
        _createProductUseCase = createProductUseCase;
        _getProductByIdUseCase = getProductByIdUseCase;
        _getAllProductsUseCase = getAllProductsUseCase;
        _updateProductUseCase = updateProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
    }

    /// <summary>
    /// Obtém todos os produtos
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Lista de produtos</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ProductListResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _getAllProductsUseCase.ExecuteAsync(cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Obtém um produto específico por ID
    /// </summary>
    /// <param name="id">ID do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Produto encontrado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetProductByIdRequest { ProductId = id };
        var response = await _getProductByIdUseCase.ExecuteAsync(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="request">Dados do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Produto criado</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _createProductUseCase.ExecuteAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response
        );
    }

    /// <summary>
    /// Atualiza um produto existente
    /// </summary>
    /// <param name="id">ID do produto</param>
    /// <param name="request">Dados atualizados do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Produto atualizado</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        // Garantir que o ID na rota corresponda ao ID no corpo da requisição
        if (id != request.ProductId)
        {
            return BadRequest("O ID na rota deve corresponder ao ID no corpo da requisição");
        }

        var response = await _updateProductUseCase.ExecuteAsync(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">ID do produto</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Resultado da operação</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { ProductId = id };
        var response = await _deleteProductUseCase.ExecuteAsync(request, cancellationToken);
        return Ok(response);
    }
}