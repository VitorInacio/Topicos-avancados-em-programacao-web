using MeusLivros.Domain.Entities;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries
{
    public class LivroQueries
    {
        public static Expression<Func<Livro, bool>> BuscarPorId(int id)
        {
            //WHERE Ed_Id = id
            return x => x.Id == id;
        }

        public static Expression<Func<Livro, bool>> BuscarPorNome(string nome)
        {
            return x => x.Nome.Contains(nome);
        }
    }
}
