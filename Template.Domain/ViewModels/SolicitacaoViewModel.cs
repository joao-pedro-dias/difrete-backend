
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

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

        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
