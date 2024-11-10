using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers
{
    public class LivroHandler : 
        IHandler<LivroInserirCommand>,
        IHandler<LivroAlterarCommand>,
        IHandler<LivroExcluirCommand>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public ICommandResult Execute(LivroInserirCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe livro com os dados do Command
            var livro = new Livro(command.Nome, command.Lancamento, command.EditoraId);

            //salva no banco de dados
            _livroRepository.Inserir(livro);

            //retorna sucesso na inclsao
            return new CommandResult(true, "Livro inserida", livro);
        }

        public ICommandResult Execute(LivroAlterarCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe livro com os dados do Command
            var livro = _livroRepository.BuscarPorId(command.Id);

            //senao existir, retorna erro
            if (livro == null)
            {
                return new CommandResult(false, "Livro não encontrada", command.Notificacoes);
            }

            livro.Nome = command.Nome;

            //salva no banco de dados
            _livroRepository.Alterar(livro);

            //retorna sucesso na alteracao
            return new CommandResult(true, "Livro alterada", livro);
        }

        public ICommandResult Execute(LivroExcluirCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe livro com os dados do Command
            var livro = _livroRepository.BuscarPorId(command.Id);

            //senao existir, retorna erro
            if (livro == null)
            {
                return new CommandResult(false, "Livro não encontrado", command.Notificacoes);
            }

            //salva no banco de dados
            _livroRepository.Excluir(livro);

            //retorna sucesso na alteracao
            return new CommandResult(true, "Livro excluído", livro);
        }
    }
}