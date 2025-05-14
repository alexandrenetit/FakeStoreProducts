using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Application.Interfaces;

namespace FakeStoreProducts.Application.UseCases.Products.UpdateProduct;

/// <summary>
/// Interface para o caso de uso de atualização de produto
/// </summary>
public interface IUpdateProductUseCase : IUseCase<UpdateProductRequest, ProductResponse>
{
}