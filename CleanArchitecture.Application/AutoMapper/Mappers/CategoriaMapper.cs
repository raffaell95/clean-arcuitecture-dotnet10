using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers;

public class CategoriaMapper : Profile
{
    public CategoriaMapper()
    {
        CreateMap<CategoriaViewModel, Categoria>()
            .ForMember(x => x.DataCadastro, y => y.MapFrom(z => DateTime.Now));

        CreateMap<Categoria, CategoriaViewModel>();
    }
}