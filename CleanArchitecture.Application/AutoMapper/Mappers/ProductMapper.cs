using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductViewModel, Product>()
            .ForMember(x => x.IdProduct, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.DateRegistration, y => y.MapFrom(z => DateTime.Now));

        CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.IdProduct));
    }
}