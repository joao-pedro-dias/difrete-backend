using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Application.ViewModels
{
    public class PersonAuthenticateResponseViewModel
    {
        public PersonAuthenticateResponseViewModel(PersonViewModel person)
        {
            this.Person = person;
        }
        public PersonViewModel Person { get; set; }
    }
}
