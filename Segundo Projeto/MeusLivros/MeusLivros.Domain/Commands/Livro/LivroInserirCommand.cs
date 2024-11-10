using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Livro
{
    public class LivroInserirCommand : Notificavel, ICommand
    {
        public LivroInserirCommand(string nome, DateTime lancamento, int editoraId)
        {
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
        public int EditoraId { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O nome do livro é obrigátorio!");
            }
            if (EditoraId == 0)
            {
                AddNotificacao("A editora do livro é obrigátorio!");
            }
            if (Lancamento == default)
            {
                AddNotificacao("A data de lançamento do livro é obrigatória!");
            }
        }
    }
}
