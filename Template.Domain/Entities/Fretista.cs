using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class Fretista: Entity
    {
        //Minha entidade Fretista
        //Entidade :: Fretista :: User
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Rntrc { get; set; }
    }
}
