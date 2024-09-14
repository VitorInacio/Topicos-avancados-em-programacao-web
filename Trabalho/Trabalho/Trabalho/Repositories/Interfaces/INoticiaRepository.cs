using Trabalho.Models;

namespace Trabalho.Repositories.Interfaces
{
    public interface INoticiaRepository
    {
        IList<Noticia> BuscarTodas();
        Noticia? BuscarPorId(int id);
        bool Adicionar(Noticia noticia);
        bool Alterar(Noticia noticia);
        bool Apagar(int id);
    }
}
