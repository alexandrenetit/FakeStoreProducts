using FakeStoreProducts.Domain.Entities;
using FakeStoreProducts.Infrastructure.DTOs;

namespace FakeStoreProducts.Infrastructure.Mapping;

/// <summary>
/// Classe responsável pelo mapeamento entre entidades de domínio e DTOs
/// </summary>
public static class MappingProfile
{
    /// <summary>
    /// Mapeia um ProductDto para uma entidade Product
    /// </summary>
    public static Product ToEntity(this ProductDto dto)
    {
        return new Product(
            dto.Id,
            dto.Title,
            dto.Price,
            dto.Description,
            dto.Category,
            dto.Image
        );
    }

    /// <summary>
    /// Mapeia uma entidade Product para um ProductDto
    /// </summary>
    public static ProductDto ToDto(this Product entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            Description = entity.Description,
            Category = entity.Category,
            Image = entity.Image
        };
    }

    /// <summary>
    /// Mapeia uma coleção de ProductDto para uma coleção de Product
    /// </summary>
    public static IEnumerable<Product> ToEntityList(this IEnumerable<ProductDto> dtos)
    {
        return dtos.Select(dto => dto.ToEntity());
    }

    /// <summary>
    /// Mapeia uma coleção de Product para uma coleção de ProductDto
    /// </summary>
    public static IEnumerable<ProductDto> ToDtoList(this IEnumerable<Product> entities)
    {
        return entities.Select(entity => entity.ToDto());
    }
}