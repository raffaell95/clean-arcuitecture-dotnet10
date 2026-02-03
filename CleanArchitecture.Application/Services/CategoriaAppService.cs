using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services;

public class CategoriaAppService : ICategoriaAppService
{

    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriaAppService(ICategoriaService categoriaService, IMapper mapper)
    {
        _categoriaService = categoriaService;
        _mapper = mapper;
    }
    
    public async Task AdicionarCategoria(CategoriaViewModel paramCategoria)
    {
        var categoria = _mapper .Map<Categoria>(paramCategoria);
        await _categoriaService.Adicionar(categoria);
    }

    public async Task Atualizar(CategoriaViewModel paramCategoria)
    {
        var categoria = _mapper.Map<Categoria>(paramCategoria);
        await _categoriaService.Atualizar(categoria);
    }

    public async Task Excluir(long id)
    {
        await _categoriaService.Excluir(id);
    }

    public async Task<CategoriaViewModel> ObterPorId(long id)
    {
        var categoria = _mapper.Map<CategoriaViewModel>(await _categoriaService.ObterPorId(id));
        return categoria;
    }

    public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
    {
        var listaCategorias = await _categoriaService.ObterTodos();
        var listViewModel = _mapper.Map<IEnumerable<CategoriaViewModel>>(listaCategorias);
        return listViewModel;
    }
}