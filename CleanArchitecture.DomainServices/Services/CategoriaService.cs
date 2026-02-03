using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(Categoria categoria)
        {            
            //chamar regras de negócio

            await _repository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria paramCategoria)
        {
            var categoria = await _repository.ObterPorId(paramCategoria.IdCategoria);
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");

            categoria.Atualizar(paramCategoria.Descricao);

            await _repository.Atualizar(categoria);
        }

        public async Task Excluir(long id)
        {
            var categoria = await _repository.ObterPorId(id);
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");

            await _repository.Excluir(id);
        }

        public async Task<Categoria> ObterPorId(long id)
        {
            var categoria = await _repository.ObterPorId(id);
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _repository.ObterTodos();            
        }
    }
}
