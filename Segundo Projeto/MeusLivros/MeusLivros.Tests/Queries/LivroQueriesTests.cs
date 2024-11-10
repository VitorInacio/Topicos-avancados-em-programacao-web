using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Queries
{
    [TestClass]
    public class LivroQueriesTests
    {
        private IEnumerable<Livro> _livros;

        public LivroQueriesTests()
        {
            var repository = new MockLivroRepository();
            _livros = repository.BuscarTodos();
        }

        [TestMethod]
        public void AoRealizarUmaConsultaComIdExistenteDeveRetornarLivro()
        {
            var result = _livros.AsQueryable().Where(LivroQueries.BuscarPorId(1));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AoRealizarUmaConsultaComIdInexistenteDeveRetornarNulo()
        {
            var result = _livros.AsQueryable().Where(LivroQueries.BuscarPorId(10)).FirstOrDefault();

            Assert.IsNull(result);
        }
    }
}
