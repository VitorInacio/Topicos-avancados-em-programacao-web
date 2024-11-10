using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Tests.Repositories
{
    public class MockLivroRepository : ILivroRepository
    {
        private IList<Livro> _livros;

        public MockLivroRepository()
        {
            _livros = new List<Livro>();
            _livros.Add(new Livro("caramba", DateTime.MinValue, 1));
            _livros.Add(new Livro("caramba2", DateTime.MinValue, 1));
        }

        public Livro? BuscarPorId(int id)
        {
            return _livros.AsQueryable().Where(LivroQueries.BuscarPorId(id)).FirstOrDefault();
        }

        public IEnumerable<Livro> BuscarTodos()
        {
            return _livros;
        }

        public void Inserir(Livro livro) { }

        public void Alterar(Livro livro) { }

        public void Excluir(Livro livro) { }
    }
}