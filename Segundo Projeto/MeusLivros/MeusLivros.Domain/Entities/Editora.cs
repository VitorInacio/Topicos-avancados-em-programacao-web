using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Entities
{
    internal class Editora : Entity
    {
        #region | Propriedades |

        public string Nome { get; set; }
        public IList<Livro> Livros { get; set; }

        #endregion

        #region | Construtores |

        public Editora(string Nome)
        {
            Nome = Nome;
            Livros = new List<Livro>();
        }

        public Editora(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Livros = new List<Livro>();
        }

        #endregion

    }
}
