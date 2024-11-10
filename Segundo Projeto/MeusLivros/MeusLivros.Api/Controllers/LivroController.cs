using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroHandler _livroHandler;
        private readonly ILivroRepository _repository;

        public LivroController(LivroHandler livroHandler, ILivroRepository repository)
        {
            _livroHandler = livroHandler;
            _repository = repository;
        }

        [HttpPost]
        public ICommandResult Inserir(LivroInserirCommand command)
        {
            var result = _livroHandler.Execute(command);
            return result;
        }

        [HttpPut]
        public ICommandResult Alterar(LivroAlterarCommand command)
        {
            var result = _livroHandler.Execute(command);
            return result;
        }

        [HttpDelete]
        public ICommandResult Excluir(LivroExcluirCommand command)
        {
            var result = _livroHandler.Execute(command);
            return result;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var result = _repository.BuscarTodos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var result = _repository.BuscarPorId(id);
            return Ok(result);
        }
    }
}
