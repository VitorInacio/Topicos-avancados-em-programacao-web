using Aula02.Models;
using Aula02.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace Aula02.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly SqlConnection _conexao;

        public TelefoneRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("conexao");
            _conexao = new SqlConnection(connectionString);

        }

        public IEnumerable<Telefone> BuscarTodos()
        {
            return _conexao.Query<Telefone>("SELECT * FROM TbTelefone");
        }

        public Telefone? BuscarPorId(int id)
        {
            string sql = "SELECT * FROM TbTelefone WHERE TelId = @id";
            var parametos = new { id };

            return _conexao.QueryFirst<Telefone>(sql, parametos);
        }

        public int Adicionar(Telefone telefone)
        {
            string sql = "INSERT INTO TbTelefone (TelNumero, OpeId, PesId) "
                + "VALUES (@TelNumero, @OpeId, @PesId)";
            var parametos = new
            {
                telefone.TelNumero,
                telefone.OpeId,
                telefone.PesId
            };

            return _conexao.Execute(sql, parametos);

        }

        public int Alterar(Telefone telefone)
        {
            var sql = @"UPDATE TbTelefone SET 
                            TelNumero = @TelNumero, 
                            OpeId = @OpeId, 
                            PesId = @PesId 
                        Where TelId = @TelId";

            var parametros = new
            {
                telefone.TelId,
                telefone.TelNumero,
                telefone.OpeId,
                telefone.PesId
            };
            return _conexao.Execute(sql, parametros);
        }

        public int Excluir(int id)
        {
            var sql = "DELETE FROM TbTelefone WHERE TelId = @id";
            var parametros = new { id };

            return _conexao.Execute(sql, parametros);
        }

    }
}
