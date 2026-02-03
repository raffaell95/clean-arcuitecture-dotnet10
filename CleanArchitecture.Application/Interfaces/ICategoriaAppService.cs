using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces;

public interface ICategoriaAppService
{
    Task AdicionarCategoria(CategoriaViewModel categoria);
    Task Atualizar(CategoriaViewModel categoria);
    Task Excluir(long id);
    Task<CategoriaViewModel> ObterPorId(long id);
    Task<IEnumerable<CategoriaViewModel>> ObterTodos();
}