
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;
using Template.Domain.Enums;

namespace Template.Application.ViewModels
{
    public class SolicitacaoFretistaViewModel
    {
        public SolicitacaoFretistaViewModel(Guid id, StatusSolicitacao status, Person person, User user)
        {
            this.Id = id;
            this.status = status.Descricao;
            this.Nome = person.Name;
            this.Celular = person.Celular;
            this.Email = user.Email;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
    }
}
