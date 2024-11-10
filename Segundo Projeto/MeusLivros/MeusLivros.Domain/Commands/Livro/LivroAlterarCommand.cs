using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Livro
{
    public class LivroAlterarCommand : Notificavel, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
        public int EditoraId { get; set; }


        public LivroAlterarCommand(int id, string nome, DateTime lancamento, int editoraId)
        {
            Id = id;
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        public void Validar()
        {
            if (Id <= 0)
            {
                AddNotificacao("Código informado inválido.");
            }
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O nome do livro é obrigatório.");
            }
            if (EditoraId == 0)
            {
                AddNotificacao("A editora do livro é obrigatória!");
            }
            if (Lancamento == default)
            {
                AddNotificacao("A data de lançamento do livro é obrigatória!");
            }
        }
    }
}
