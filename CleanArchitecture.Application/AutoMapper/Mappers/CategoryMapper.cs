using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<CategoryViewModel, Category>()
            .ForMember(x => x.DateRegistration, y => y.MapFrom(z => DateTime.Now));

        CreateMap<Category, CategoryViewModel>();
    }
}