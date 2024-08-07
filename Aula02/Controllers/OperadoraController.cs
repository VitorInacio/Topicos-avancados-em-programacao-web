using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Aula02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    SqlConnection conexao;

    public OperadoraController()
    {
        conexao = new SqlConnection(
            @"Server=LAB-03-PC-11\SQLEXPRESS01; 
            Database=AgendaFoneDb; 
            Trusted_Connection=True;"
        );

        conexao.Open();
    }
}
