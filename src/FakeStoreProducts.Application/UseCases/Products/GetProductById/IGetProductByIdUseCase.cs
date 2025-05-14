using FakeStoreProducts.Application.DTOs.Requests;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Application.Interfaces;

namespace FakeStoreProducts.Application.UseCases.Products.GetProductById;

/// <summary>
/// Interface para o caso de uso de obtenção de produto por ID
/// </summary>
public interface IGetProductByIdUseCase : IUseCase<GetProductByIdRequest, ProductResponse>
{
}