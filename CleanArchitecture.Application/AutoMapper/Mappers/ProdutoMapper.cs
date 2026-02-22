using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers;

public class ProdutoMapper : Profile
{
    public ProdutoMapper()
    {
        CreateMap<ProdutoViewModel, Produto>()
            .ForMember(x => x.IdProduto, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.DataCadastro, y => y.MapFrom(z => DateTime.Now));

        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.IdProduto));
    }
}