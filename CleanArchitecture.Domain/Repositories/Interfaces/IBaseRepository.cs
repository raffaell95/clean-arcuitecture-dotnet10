using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> ObterPorId(long id);
        Task<IEnumerable<T>> ObterTodos();
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Excluir(long id);
    }
}
