using AutoMapper;
using core.Entities;
using store_api.Dto;
using store_api.Helpers;

namespace store_api.Profiles;

public class ProductProfile : Profile
{   
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }

}
