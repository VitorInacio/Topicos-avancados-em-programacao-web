using MeusLivros.Domain.Commands.Livro;

namespace MeusLivros.Tests.Commands
{
    [TestClass]
    public class LivroAlterarCommandTests
    {
        [TestMethod]
        public void DadoUmComandoInvalidoDeveRetornarInvalida()
        {
            var command = new LivroAlterarCommand(0, "", DateTime.MinValue, 1);  // Passando todos os parâmetros corretamente

            command.Validar();

            Assert.IsTrue(command.isInvalida);
            Assert.IsTrue(command.Notificacoes.Any());
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveRetornarValida()
        {
            var command = new LivroAlterarCommand(1, "Nome", DateTime.Now, 1);  // Usando DateTime.Now para data atual

            command.Validar();

            Assert.IsTrue(command.isValida);
        }
    }
}
