using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetById(long id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task ToUpdate(T entity);
    Task Remove(long id);
}
