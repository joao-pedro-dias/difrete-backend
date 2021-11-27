
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;
using Template.Domain.Enums;

namespace Template.Application.ViewModels
{
    public class SolicitacaoViewModel
    {
        public SolicitacaoViewModel(Fretista fretista)
        {
            Id = fretista.Id;
            RazaoSocial = fretista.RazaoSocial;
            Cnpj = fretista.Cnpj;
            Nome = fretista.User?.Person?.Name;
            Celular = fretista.User?.Person?.Celular;
            Email = fretista.User?.Email;
        }
        public SolicitacaoViewModel(Solicitacao solicitacao, StatusSolicitacao status, Fretista fretista, Person person, User usuario)
        {
            Id = solicitacao.Id;
            this.status = status.Descricao;
            RazaoSocial = fretista.RazaoSocial;
            Cnpj = fretista.Cnpj;
            Nome = person?.Name;
            Celular = person?.Celular;
            Email = usuario?.Email;
        }

        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
    }
}
