using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Handlers
{
    [TestClass]
    public class LivroHandlerTests
    {
        private readonly ILivroRepository _repository;
        private readonly LivroHandler _handler;
        public LivroHandlerTests()
        {
            _repository = new MockLivroRepository();
            _handler = new LivroHandler(_repository);
        }

        #region Inserir

        [TestMethod]
        public void DadoUmComandoDeInserirValidoDeveRetornarSucessoTrue()
        {
            var command = new LivroInserirCommand("Nome", DateTime.MinValue, 1);

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeInserirInvalidoDeveRetornarSucessoFalse()
        {
            var command = new LivroInserirCommand("Nome", DateTime.MinValue, 1);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion

        #region Alterar

        [TestMethod]
        public void DadoUmComandoDeAlterarValidoDeveRetornarSucessoTrue()
        {
            var command = new LivroAlterarCommand(1,"Nome", DateTime.MinValue, 1);

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeAlterarInvalidoDeveRetornarSucessoFalse()
        {
            var command = new LivroAlterarCommand(0, "Nome", DateTime.MinValue, 1);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeAlterarValidoMasComLivroInexistenteDeveRetornarSucessoFalse()
        {
            var command = new LivroAlterarCommand(9, "Nome", DateTime.MinValue, 1);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion

        #region Excluir

        [TestMethod]
        public void DadoUmComandoDeExcluirValidoDeveRetornarSucessoTrue()
        {
            var command = new LivroExcluirCommand(1);

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeExcluirInvalidoDeveRetornarSucessoFalse()
        {
            var command = new LivroExcluirCommand(0);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeExcluirValidoMasComLivroInexistenteDeveRetornarSucessoFalse()
        {
            var command = new LivroExcluirCommand(9);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion
    }
}