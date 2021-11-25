
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Application.ViewModels
{
    public class FretistaViewModel
    {
        public FretistaViewModel(Fretista fretista)
        {
            Id = fretista.Id;
            RazaoSocial = fretista.RazaoSocial;
            Cnpj = fretista.Cnpj;
        }
        public FretistaViewModel(Fretista fretista, User user, Person person)
        {
            Id = fretista.Id;
            RazaoSocial = fretista.RazaoSocial;
            Cnpj = fretista.Cnpj;
            Nome = user?.Person?.Name;
            Celular = person?.Celular;
            Email = user?.Email;
        }

        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
