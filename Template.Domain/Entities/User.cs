using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Enum;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class User: Entity
    {
        /*aqui vou criar meus atribtuos de user*/
        public string Email { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
        public LoginType LoginType { get; set; }
    }
}
