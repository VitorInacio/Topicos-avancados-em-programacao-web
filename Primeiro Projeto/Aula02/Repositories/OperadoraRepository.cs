using System.Data.SqlClient;

namespace Aula02.Repositories
{

    public class OperadoraRepository
    {
        SqlConnection conexao;

        public OperadoraRepository()
        {
            conexao = new SqlConnection(
            @"Server=LAB-01-MICRO-15\SQLEXPRESS;
            Database=AgendaFoneDb;
            Trusted_Connection=True;"
        );
            //            Encrypt=False;

        }

        public IList<string> BuscarTodas()
        {
            try
            {
                conexao.Open();

                string sql = "SELECT * FROM TbOperadora";
                using SqlCommand command = new SqlCommand(sql, conexao);
                using SqlDataReader reader = command.ExecuteReader();
                var retorno = new List<string>();

                while (reader.Read())
                {
                    retorno.Add(reader["OpeNome"].ToString() ?? "");
                }

                return retorno;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Adicionar(String nome)

        {
            try
            {
                conexao.Open();

                string sql = "INSERT INTO TbOperadora (OpeNome) VALUES (@OpeNome)";

                using SqlCommand command = new SqlCommand(sql, conexao);
                // command.Parameters.Add("@OpeNome", SqlDbType.VarChar).Value = nome;
                command.Parameters.AddWithValue("@OpeNome", nome);

                command.ExecuteNonQuery();

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.Open();
            }
        }
    }

}

