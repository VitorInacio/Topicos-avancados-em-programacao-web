using MeusLivros.Domain.Commands.Livro;

namespace MeusLivros.Tests.Commands
{
    [TestClass]
    public class LivroInserirCommandTests
    {
        [TestMethod]
        public void DadoUmComandoInvalidoDeveRetornarInvalida()
        {
            var command = new LivroInserirCommand("", DateTime.MinValue, 1);

            command.Validar();

            Assert.IsTrue(command.isInvalida);
            Assert.IsTrue(command.Notificacoes.Any());
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveRetornarValida()
        {
            var command = new LivroInserirCommand("", DateTime.Now, 1);

            command.Validar();

            Assert.IsTrue(command.isValida);
        }
    }
}
