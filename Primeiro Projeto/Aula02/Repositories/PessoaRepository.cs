using Aula02.Models;
using Dapper;
using System.Data.SqlClient;

namespace Aula02.Repositories
{
    public class PessoaRepository
    {
        SqlConnection conexao;

        public PessoaRepository()
        {
            conexao = new SqlConnection(
            @"Server=LAB-01-MICRO-10\SQLEXPRESS;
            Database=AgendaFoneDb;
            Trusted_Connection=True;"
        );
        }

        public IEnumerable<Pessoa> BuscarTodas()
        {
            return conexao.Query<Pessoa>("SELECT * FROM TbPessoa");     // fazendo a mesma coisa que no OperadoraRepository, porém utilizando a extensão Dapper

        }
    }
}
