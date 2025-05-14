using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Application.Interfaces;

namespace FakeStoreProducts.Application.UseCases.Products.CreateProduct;

/// <summary>
/// Interface para o caso de uso de criação de produto
/// </summary>
public interface ICreateProductUseCase : IUseCase<CreateProductRequest, ProductResponse>
{
}