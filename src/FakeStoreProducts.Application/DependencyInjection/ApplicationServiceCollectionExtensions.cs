using FakeStoreProducts.Application.Common.Behaviors;
using FakeStoreProducts.Application.Common.Mappings;
using FakeStoreProducts.Application.Interfaces;
using FakeStoreProducts.Application.UseCases.Products.CreateProduct;
using FakeStoreProducts.Application.UseCases.Products.DeleteProduct;
using FakeStoreProducts.Application.UseCases.Products.GetAllProducts;
using FakeStoreProducts.Application.UseCases.Products.GetProductById;
using FakeStoreProducts.Application.UseCases.Products.UpdateProduct;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FakeStoreProducts.Application.DependencyInjection;

/// <summary>
/// Extensões para configuração de serviços da camada de aplicação
/// </summary>
public static class ApplicationServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona os serviços da camada de aplicação
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <returns>Coleção de serviços com os serviços da aplicação adicionados</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registrar AutoMapper
        services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);

        // Registrar validadores
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Registrar comportamentos
        services.AddScoped(typeof(IRequestHandler<,>), typeof(ValidationBehavior<,>));

        // Registrar casos de uso
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
        services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
        services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();

        return services;
    }
}