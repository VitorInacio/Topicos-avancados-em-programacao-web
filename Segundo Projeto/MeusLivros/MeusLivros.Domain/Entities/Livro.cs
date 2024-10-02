using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Entities
{
    internal class Livro : Entity
    {
        #region | Propriedades |

        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }

        #endregion

        #region | Construtores |

        public Livro(string nome, DateTime lancamento, int editoraId)
        {
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        public Livro(int id, String nome, DateTime lancamento, int editoraId)
        {
            Id= id;
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        #endregion
    }
}
