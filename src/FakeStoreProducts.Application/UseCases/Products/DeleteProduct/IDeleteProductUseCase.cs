using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Application.Interfaces;

namespace FakeStoreProducts.Application.UseCases.Products.DeleteProduct;

/// <summary>
/// Interface para o caso de uso de exclusão de produto
/// </summary>
public interface IDeleteProductUseCase : IUseCase<DeleteProductRequest, BaseResponse>
{
}