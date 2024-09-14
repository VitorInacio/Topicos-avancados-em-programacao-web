using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Trabalho.Repositories.Interfaces;

namespace Trabalho.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository repository;

    public AutorController(IAutorRepository autorRepository)
    {
        repository = autorRepository;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        try
        {
            var lista = repository.BuscarTodos();
            if (lista.Any())
            {
                return Ok(lista); // Retorna status 200 com a lista de autores
            }
            else
            {
                return NoContent(); // Retorna status 204 caso não haja autores
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Autor autor)
    {
        try
        {
            return Ok(repository.Adicionar(autor)); // Retorna status 200 ao adicionar
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] Autor autor)
    {
        try
        {
            var result = repository.Alterar(autor);
            return Ok(result); // Retorna status 200 ao alterar
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpDelete]
    public IActionResult Apagar(int id)
    {
        try
        {
            var result = repository.Apagar(id);
            return Ok(result); // Retorna status 200 ao apagar
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        try
        {
            var result = repository.BuscarPorId(id);
            if (result != null)
            {
                return Ok(result); // Retorna status 200 com o autor encontrado
            }
            else
            {
                return NotFound(); // Retorna status 404 se o autor não for encontrado
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }
}
