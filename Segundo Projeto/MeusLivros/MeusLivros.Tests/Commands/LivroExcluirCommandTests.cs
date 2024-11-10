using MeusLivros.Domain.Commands.Livro;

namespace MeusLivros.Tests.Commands
{
    [TestClass]
    public class LivroExcluirCommandTests
    {
        [TestMethod]
        public void DadoUmComandoInvalidoDeveRetornarInvalida()
        {
            var command = new LivroExcluirCommand(0);

            command.Validar();

            Assert.IsTrue(command.isInvalida);
            Assert.IsTrue(command.Notificacoes.Any());
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveRetornarValida()
        {
            var command = new LivroExcluirCommand(1);

            command.Validar();

            Assert.IsTrue(command.isValida);
        }
    }
}
