﻿using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Editora
{
    public class EditoraAlterarCommand : Notificavel, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public EditoraAlterarCommand(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public void Validar()
        {
            if (Id == 0)
            {
                AddNotificacao("Código informado inválido");
            };
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O nome da editora é obrigatório");
            };
        }
    }
}
