using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Trabalho.Repositories.Interfaces;

namespace Trabalho.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiaController : ControllerBase
{
    private readonly INoticiaRepository repository;

    public NoticiaController(INoticiaRepository noticiaRepository)
    {
        repository = noticiaRepository;
    }

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        try
        {
            var lista = repository.BuscarTodas();
            if (lista.Any())
            {
                return Ok(lista); // Retorna status 200 com a lista de notícias
            }
            else
            {
                return NoContent(); // Retorna status 204 caso não haja notícias
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Noticia noticia)
    {
        try
        {
            return Ok(repository.Adicionar(noticia)); // Retorna status 200 ao adicionar
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] Noticia noticia)
    {
        try
        {
            var result = repository.Alterar(noticia);
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
                return Ok(result); // Retorna status 200 com a notícia encontrada
            }
            else
            {
                return NotFound(); // Retorna status 404 se a notícia não for encontrada
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); // Retorna status 500 em caso de erro
        }
    }
}
    

