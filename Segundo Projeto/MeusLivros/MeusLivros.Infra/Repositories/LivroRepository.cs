using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public void Inserir(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void Alterar(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Livro livro)
        {
            _context.Remove(livro);
            _context.SaveChanges();
        }

        public Livro? BuscarPorId(int id)
        {
            return _context.Livros
                //.Where(x => x.Id == id)
                .Where(LivroQueries.BuscarPorId(id))
                .FirstOrDefault();
        }

        public IEnumerable<Livro> BuscarTodos()
        {
            return _context.Livros
                .AsNoTracking() //Remove o rastreamento do EF
                .OrderBy(x => x.Nome);
        }
    }
}
