using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Editora
{
    public class EditoraExcluirCommand : Notificavel, ICommand
    {
        public int Id { get; set; }

        public EditoraExcluirCommand(int id)
        {
            Id = id;
        }

        public void Validar()
        {
            if (Id <= 0)
            {
                AddNotificacao("Código informado inválido");
            }
        }
    }
}
