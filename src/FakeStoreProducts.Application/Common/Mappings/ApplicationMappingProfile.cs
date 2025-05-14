using AutoMapper;
using FakeStoreProducts.Application.DTOs.Responses;
using FakeStoreProducts.Infrastructure.DTOs;

namespace FakeStoreProducts.Application.Common.Mappings;

/// <summary>
/// Perfil de mapeamento para a camada de aplicação
/// </summary>
public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // Mapeamento de DTOs da infraestrutura para DTOs da aplicação
        CreateMap<ProductDto, ProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image));

        // Mapeamento de requests para DTOs da infraestrutura
        CreateMap<DTOs.Requests.CreateProductRequest, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<DTOs.Requests.UpdateProductRequest, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}