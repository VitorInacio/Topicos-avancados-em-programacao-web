using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Trabalho.Models;
using Trabalho.Repositories.Interfaces;

namespace Trabalho.Repositories;

public class AutorRepository : IAutorRepository
{
    SqlConnection conexao;

    public AutorRepository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("conexao");
        conexao = new SqlConnection(connectionString);
    }

    public IList<Autor> BuscarTodos()
    {
        try
        {
            conexao.Open();

            string sql = "SELECT * FROM Autor";
            using SqlCommand command = new SqlCommand(sql, conexao);
            using SqlDataReader reader = command.ExecuteReader();
            var retorno = new List<Autor>();

            while (reader.Read())
            {
                var autor = new Autor
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email")
                };
                retorno.Add(autor);
            }

            return retorno;
        }
        finally
        {
            conexao.Close();
        }
    }

    public bool Adicionar(Autor autor)
    {
        try
        {
            conexao.Open();

            string sql = "INSERT INTO Autor (Nome, Email) VALUES (@Nome, @Email)";
            using SqlCommand command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Nome", autor.Nome);
            command.Parameters.AddWithValue("@Email", autor.Email);
            command.ExecuteNonQuery();

            return true;
        }
        finally
        {
            conexao.Close();
        }
    }

    public bool Alterar(Autor autor)
    {
        try
        {
            conexao.Open();

            string sql = @"
                    UPDATE Autor SET
                        Nome = @Nome,
                        Email = @Email
                    WHERE Id = @Id";

            using var command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Nome", autor.Nome);
            command.Parameters.AddWithValue("@Email", autor.Email);
            command.Parameters.AddWithValue("@Id", autor.Id);

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

            string sql = "DELETE FROM Autor WHERE Id = @Id";
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

    public Autor? BuscarPorId(int codigo)
    {
        try
        {
            conexao.Open();

            string sql = "SELECT * FROM Autor WHERE Id = @Id";
            using var command = new SqlCommand(sql, conexao);
            command.Parameters.AddWithValue("@Id", codigo);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Autor
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome")
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
