using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Trabalho.Models;
using Trabalho.Repositories.Interfaces;

namespace Trabalho.Repositories;


public class NoticiaRepository : INoticiaRepository
{
    SqlConnection conexao;

    public NoticiaRepository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("conexao");
        conexao = new SqlConnection(connectionString);
    }

    public IList<Noticia> BuscarTodas()
    {
        try
        {
            conexao.Open();

            string sql = "SELECT * FROM Noticia";
            using SqlCommand command = new SqlCommand(sql, conexao);
            using SqlDataReader reader = command.ExecuteReader();
            var retorno = new List<Noticia>();

            while (reader.Read())
            {
                var noticia = new Noticia
                {
                    Id = reader.GetInt32("Id"),
                    Titulo = reader.GetString("Titulo"),
                    Texto = reader.GetString("Texto"),
                    Data = reader.GetDateTime("Data"),
                    AutorId = reader.GetInt32("AutorId")
                };
                retorno.Add(noticia);
            }

            return retorno;
        }
        finally
        {
            conexao.Close();
        }
    }

    public bool Adicionar(Noticia noticia)
    {
        try
        {
            conexao.Open();

            string sql = "INSERT INTO Noticia (Titulo, Texto, Data, AutorId) VALUES (@Titulo, @Texto, @Data, @AutorId)";
            using SqlCommand command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Titulo", noticia.Titulo);
            command.Parameters.AddWithValue("@Texto", noticia.Texto);
            command.Parameters.AddWithValue("@Data", noticia.Data);
            command.Parameters.AddWithValue("@AutorId", noticia.AutorId);
            command.ExecuteNonQuery();

            return true;
        }
        finally
        {
            conexao.Close();
        }
    }

    public bool Alterar(Noticia noticia)
    {
        try
        {
            conexao.Open();

            string sql = @"
                    UPDATE Noticia SET
                        Titulo = @Titulo,
                        Texto = @Texto,
                        Data = @Data,
                        AutorId = @AutorId
                    WHERE Id = @Id";

            using var command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Titulo", noticia.Titulo);
            command.Parameters.AddWithValue("@Texto", noticia.Texto);
            command.Parameters.AddWithValue("@Data", noticia.Data);
            command.Parameters.AddWithValue("@AutorId", noticia.AutorId);
            command.Parameters.AddWithValue("@Id", noticia.Id);
            command.ExecuteNonQuery();

            return true;
        }
        finally
        {
            conexao.Close();
        }
    }

    public bool Apagar(int codigo)
    {
        try
        {
            conexao.Open();

            string sql = "DELETE FROM Noticia WHERE Id = @Id";
            using var command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Id", codigo);

            command.ExecuteNonQuery();

            return true;
        }
        finally
        {
            conexao.Close();
        }
    }

    public Noticia? BuscarPorId(int codigo)
    {
        try
        {
            conexao.Open();

            string sql = "SELECT * FROM Noticia WHERE Id = @Id";
            using var command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Id", codigo);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Noticia
                {
                    Id = reader.GetInt32("Id"),
                    Titulo = reader.GetString("Titulo"),
                    Texto = reader.GetString("Texto"),
                    Data = reader.GetDateTime("Data"),
                    AutorId = reader.GetInt32("AutorId")
                };
            }

            return null;
        }
        finally
        {
            conexao.Close();
        }
    }
}
