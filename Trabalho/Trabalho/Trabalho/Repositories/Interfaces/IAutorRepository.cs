using Trabalho.Models;

namespace Trabalho.Repositories.Interfaces
{
    public interface IAutorRepository
    {
        public IList<Autor> BuscarTodos();
        public Autor? BuscarPorId(int id);
        public bool Adicionar(Autor autor);
        public bool Alterar(Autor autor);
        public bool Apagar(int id);
    }
}
